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
    private readonly IBookRepository _bookRepository;

    public ChaptersService(IChaptersRepository chaptersRepository, IUnitOfWork unitOfWork,IBookRepository bookRepository)
    {
        _chaptersRepository = chaptersRepository;
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Chapters>> ListAsync()
    {
        return await _chaptersRepository.ListAsync();
    }

    public async Task<ChaptersResponse> FindByIdAsync(int chaptersId)
    {
        var chapters = await _chaptersRepository.FindByIdAsync(chaptersId);
        
        if (chapters == null)
            return new ChaptersResponse("Chapter not found");
        
        return new ChaptersResponse(chapters);
    }
    

    public async Task<ChaptersResponse> SaveAsync(Chapters chapters)
    {
        //validate Book
        var existingBook = await _bookRepository.FindByIdAsync(chapters.BookId);

        if (existingBook == null)
            return new ChaptersResponse("Invalid Book");
        
        try
        {
            //Add
            await _chaptersRepository.AddAsync(chapters);

            //Complete transaction
            await _unitOfWork.CompleteAsync();

            //Return response
            return new ChaptersResponse(chapters);
        }
        catch (Exception e)
        {
            return new ChaptersResponse($"An error ocurred while saving the chapters element: {e.Message}");
        }
    }

    public async Task<ChaptersResponse> UpdateAsync(int chaptersId, Chapters chapters)
    {
        var existingChapters = await _chaptersRepository.FindByIdAsync(chaptersId);
        if (existingChapters == null)
            return new ChaptersResponse("Genre not found.");
        existingChapters.Title = chapters.Title;
        existingChapters.Document_content_url = chapters.Document_content_url;
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