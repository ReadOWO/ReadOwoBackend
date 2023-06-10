using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class ChaptersService : IChaptersService
{
      private readonly IChaptersRepository _chaptersRepository;
    private readonly IUnitOfWork _unitOfWork;


    public ChaptersService(IChaptersRepository chaptersRepository, IUnitOfWork unitOfWork)
    {
        _chaptersRepository = chaptersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Chapters>> ListAsync()
    {
        return await _chaptersRepository.ListAsync();
    }

    public async Task<IEnumerable<Chapters>> ListByChaptersIdAsync(int chaptersId)
    {
        return await _chaptersRepository.ListAsync();
    }

    public async Task<ChaptersResponse> SaveAsync(Chapters chapters)
    {
        try
        {
            await _chaptersRepository.AddAsync(chapters);
            await _unitOfWork.CompleteAsync();
            return new ChaptersResponse(chapters);
        }
        catch (Exception e)
        {
            return new ChaptersResponse($"An error occurred while saving the chapters: {e.Message}");
        }
    }

    public async Task<ChaptersResponse> UpdateAsync(int chaptersId, Chapters chapters)
    {
        var existingChapters = await _chaptersRepository.FindByIdAsync(chaptersId);
        if (existingChapters == null)
            return new ChaptersResponse("Genre not found.");
        existingChapters.Title = chapters.Title;
        try
        {
            _chaptersRepository.Update(existingChapters);
            await _unitOfWork.CompleteAsync();
            return new ChaptersResponse(existingChapters);
        }
        catch (Exception e)
        {
            return new ChaptersResponse($"An error occurred while updating the books:{e.Message}");
        }
    }

    public async Task<ChaptersResponse> DeleteAsync(int chaptersId)
    {
        var existingChapters = await _chaptersRepository.FindByIdAsync(chaptersId);
        if (existingChapters == null)
            return new ChaptersResponse("chapters not found.");
        try
        {
            _chaptersRepository.Remove(existingChapters);
            await _unitOfWork.CompleteAsync();
            return new ChaptersResponse(existingChapters);
        }
        catch (Exception e)
        {
            return new ChaptersResponse($"An error occurred while deleting the chapters: {e.Message}");
        }
    }
}