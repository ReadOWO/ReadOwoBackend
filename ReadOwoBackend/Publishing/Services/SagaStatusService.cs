using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class SagaStatusService : ISagaStatusService
{
    private readonly ISagaStatusRepository _sagaStatusRepository;
    private readonly IUnitOfWork _unitOfWork;


    public SagaStatusService(ISagaStatusRepository sagaStatusRepository, IUnitOfWork unitOfWork)
    {
        _sagaStatusRepository = sagaStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SagaStatus>> ListAsync()
    {
        return await _sagaStatusRepository.ListAsync();
    }
    
    public async Task<SagaStatusResponse> FindByIdAsync(int sagaStatusId)
    {
        var existingSagaStatus = await _sagaStatusRepository.FindByIdAsync(sagaStatusId);
        
        if (existingSagaStatus == null)
            return new SagaStatusResponse("Saga not found");
        
        return new SagaStatusResponse(existingSagaStatus);
    }

    public async Task<SagaStatusResponse> SaveAsync(SagaStatus sagaStatus)
    {
        try
        {
            await _sagaStatusRepository.AddAsync(sagaStatus);
            await _unitOfWork.CompleteAsync();
            return new SagaStatusResponse(sagaStatus);

        }
        catch (Exception e)
        {
            return new SagaStatusResponse($"An error occurred while saving the tutorial: {e.Message}");
        }

        
    }

    public async Task<SagaStatusResponse> UpdateAsync(int sagaStatusId, SagaStatus sagaStatus)
    {
        var existingSagaStatus = await _sagaStatusRepository.FindByIdAsync(sagaStatusId);
        
        // Validate Saga

        if (existingSagaStatus == null)
            return new SagaStatusResponse("Saga not found.");

        // Modify Fields
        existingSagaStatus.Name = sagaStatus.Name;

        try
        {
            _sagaStatusRepository.Update(existingSagaStatus);
            await _unitOfWork.CompleteAsync();

            return new SagaStatusResponse(existingSagaStatus);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new SagaStatusResponse($"An error occurred while updating the tutorial: {e.Message}");
        }

    }

    public async Task<SagaStatusResponse> DeleteAsync(int sagaStatusId)
    {
        var existingSagaStatus = await _sagaStatusRepository.FindByIdAsync(sagaStatusId);
        
        // Validate Tutorial

        if (existingSagaStatus == null)
            return new SagaStatusResponse("Tutorial not found.");
        
        try
        {
            _sagaStatusRepository.Remove(existingSagaStatus);
            await _unitOfWork.CompleteAsync();

            return new SagaStatusResponse(existingSagaStatus);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new SagaStatusResponse($"An error occurred while deleting the tutorial: {e.Message}");
        }

    }
}