using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class BookStatusService : IBookStatusService
{
    private readonly IBookStatusRepository _bookStatusRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public BookStatusService(IBookStatusRepository bookStatusRepository, IUnitOfWork unitOfWork)
    {
        _bookStatusRepository = bookStatusRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<BookStatus>> ListAsync()
    {
        return await _bookStatusRepository.ListAsync();
    }
    
    public async Task<BookStatusResponse> FindByIdAsync(int bookStatusId)
    {
        var existingBookStatus = await _bookStatusRepository.FindByIdAsync(bookStatusId);
        
        if (existingBookStatus == null)
            return new BookStatusResponse("Book status not found");
        
        return new BookStatusResponse(existingBookStatus);
    }

    public async Task<BookStatusResponse> SaveAsync(BookStatus bookStatus)
    {
        try
        {
            await _bookStatusRepository.AddAsync(bookStatus);
            await _unitOfWork.CompleteAsync();
            return new BookStatusResponse(bookStatus);

        }
        catch (Exception e)
        {
            return new BookStatusResponse($"An error occurred while saving the book status: {e.Message}");
        }

        
    }

    public async Task<BookStatusResponse> UpdateAsync(int bookStatusId, BookStatus bookStatus)
    {
        var existingBookStatus = await _bookStatusRepository.FindByIdAsync(bookStatusId);
        
        // Validate Saga

        if (existingBookStatus == null)
            return new BookStatusResponse("Book status not found,");

        // Modify Fields
        existingBookStatus.Name = bookStatus.Name;

        try
        {
            _bookStatusRepository.Update(existingBookStatus);
            await _unitOfWork.CompleteAsync();

            return new BookStatusResponse(existingBookStatus);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new BookStatusResponse($"An error occurred while updating the book status: {e.Message}");
        }

    }

    public async Task<BookStatusResponse> DeleteAsync(int bookStatusId)
    {
        var existingBookStatus = await _bookStatusRepository.FindByIdAsync(bookStatusId);
        
        // Validate Tutorial

        if (existingBookStatus == null)
            return new BookStatusResponse("Book status not found.");
        
        try
        {
            _bookStatusRepository.Remove(existingBookStatus);
            await _unitOfWork.CompleteAsync();

            return new BookStatusResponse(existingBookStatus);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new BookStatusResponse($"An error occurred while deleting the book status: {e.Message}");
        }
    }
}