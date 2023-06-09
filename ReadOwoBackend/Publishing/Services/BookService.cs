using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookStatusRepository _bookStatusRepository;

    public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork,
        IBookStatusRepository bookStatusRepository)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _bookStatusRepository = bookStatusRepository;
    }

    public async Task<IEnumerable<Book>> ListAsync()
    {
        return await _bookRepository.ListAsync();
    }

    public async Task<BookResponse> FindByIdAsync(int bookId)
    {
        var book = await _bookRepository.FindByIdAsync(bookId);

        if (book == null)
            return new BookResponse("Book not found");

        return new BookResponse(book);
    }

    public async Task<BookResponse> SaveAsync(Book book)
    {
        //Validate Book Status
        var existingBookStatus = await _bookStatusRepository.FindByIdAsync(book.BookStatusId);

        if (existingBookStatus == null)
            return new BookResponse("Invalid Book Status");

        try
        {
            //Add
            await _bookRepository.AddAsync(book);

            //Complete transaction
            await _unitOfWork.CompleteAsync();

            //Return response
            return new BookResponse(book);
        }
        catch (Exception e)
        {
            //Error handling
            return new BookResponse($"An error ocurred while saving the book: {e.Message}");
        }
    }

    public async Task<BookResponse> UpdateAsync(int bookId, Book book)
    {
        //Validate Book
        var existingBook = await _bookRepository.FindByIdAsync(bookId);

        if (existingBook == null)
            return new BookResponse("Book not found.");
        
        //Validate BookStatusId
        var existingBookStatus = await _bookStatusRepository.FindByIdAsync(book.BookStatusId);

        if (existingBookStatus == null)
            return new BookResponse("Invalid book status.");
        
        //Update
        existingBook.Title = book.Title;
        existingBook.Synopsis = book.Synopsis;
        existingBook.PublishedAt = book.PublishedAt;

        try
        {
            _bookRepository.Update(existingBook);
            await _unitOfWork.CompleteAsync();

            return new BookResponse(existingBook);
        }
        catch (Exception e)
        {
            //Error handling
            return new BookResponse($"An error ocurred while updating the book: {e.Message}");
        }
    }

    public async Task<BookResponse> DeleteAsync(int bookId)
    {
        //Validate Book
        var existingBook = await _bookRepository.FindByIdAsync(bookId);

        if (existingBook == null)
            return new BookResponse("Book not found.");

        try
        {
            _bookRepository.Remove(existingBook);
            await _unitOfWork.CompleteAsync();

            return new BookResponse(existingBook);
        }
        catch (Exception e)
        {
            //Error handling
            return new BookResponse($"An error ocurred while deleting the book: {e.Message}");
        }
    }
}