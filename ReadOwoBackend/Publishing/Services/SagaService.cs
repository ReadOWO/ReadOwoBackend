using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class SagaService : ISagaService
{
    private readonly ISagaRepository _sagaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISagaStatusRepository _sagaStatusRepository;


    public SagaService(ISagaRepository sagaRepository, IUnitOfWork unitOfWork, ISagaStatusRepository sagaStatusRepository)
    {
        _sagaRepository = sagaRepository;
        _unitOfWork = unitOfWork;
        _sagaStatusRepository = sagaStatusRepository;
    }
    
    public async Task<IEnumerable<Saga>> ListAsync()
    {
        return await _sagaRepository.ListAsync();
    }
    
    public async Task<SagaResponse> FindByIdAsync(int sagaId)
    {
        var saga = await _sagaRepository.FindByIdAsync(sagaId);
        
        if (saga == null)
            return new SagaResponse("Saga not found");
        
        return new SagaResponse(saga);
    }

    public async Task<SagaResponse> SaveAsync(Saga saga)
    {
        // Validate CategoryId

        var existingSagaStatus = await _sagaStatusRepository.FindByIdAsync(saga.SagaStatusId);

        if (existingSagaStatus == null)
            return new SagaResponse("Invalid Saga Status");

        try
        {
            // Add Tutorial
            await _sagaRepository.AddAsync(saga);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new SagaResponse(saga);

        }
        catch (Exception e)
        {
            // Error Handling
            return new SagaResponse($"An error occurred while saving the tutorial: {e.Message}");
        }

        
    }

    public async Task<SagaResponse> UpdateAsync(int sagaId, Saga saga)
    {
        // Validate Saga
        var existingSaga = await _sagaRepository.FindByIdAsync(sagaId);

        if (existingSaga == null)
            return new SagaResponse("Saga not found.");

        // Validate SagaStatusId

        var existingSagaStatus = await _sagaStatusRepository.FindByIdAsync(saga.SagaStatusId);

        if (existingSagaStatus == null)
            return new SagaResponse("Invalid Saga Status");

        // Modify Fields
        existingSaga.Title = saga.Title;
        existingSaga.Synopsis = saga.Synopsis;

        try
        {
            _sagaRepository.Update(existingSaga);
            await _unitOfWork.CompleteAsync();

            return new SagaResponse(existingSaga);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new SagaResponse($"An error occurred while updating the tutorial: {e.Message}");
        }

    }

    public async Task<SagaResponse> DeleteAsync(int sagaId)
    {
        var existingSaga = await _sagaRepository.FindByIdAsync(sagaId);
        
        // Validate Tutorial

        if (existingSaga == null)
            return new SagaResponse("Tutorial not found.");
        
        try
        {
            _sagaRepository.Remove(existingSaga);
            await _unitOfWork.CompleteAsync();

            return new SagaResponse(existingSaga);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new SagaResponse($"An error occurred while deleting the tutorial: {e.Message}");
        }

    }
}