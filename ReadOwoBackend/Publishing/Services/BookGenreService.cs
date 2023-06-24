using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class BookGenreService : IBookGenreService
{
    private readonly IBookGenreRepository _bookGenreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;

    public BookGenreService(IBookGenreRepository bookGenreRepository, IUnitOfWork unitOfWork, IBookRepository bookRepository, IGenreRepository genreRepository)
    {
        _bookGenreRepository = bookGenreRepository;
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<BookGenre>> ListAsync()
    {
        return await _bookGenreRepository.ListAsync();
    }

    public async Task<BookGenreResponse> FindByIdAsync(int id)
    {
        var bookGenre = await _bookGenreRepository.FindByBookGenreId(id);
        if (bookGenre == null)
            return new BookGenreResponse("Book Genre not found");
        return new BookGenreResponse(bookGenre);
    }

    public async Task<BookGenreResponse> SaveAsync(BookGenre bookGenre)
    {
        //validate Book
        var existingBook = await _bookRepository.FindByIdAsync(bookGenre.BookId);

        if (existingBook == null)
            return new BookGenreResponse("Invalid Book");

        //validate Genre
        var existingGenre = await _genreRepository.FindByIdAsync(bookGenre.GenreId);
        if (existingGenre == null)
            return new BookGenreResponse("Invalid Genre");
        try
        {
            //Add
            await _bookGenreRepository.AddAsync(bookGenre);

            //Complete transaction
            await _unitOfWork.CompleteAsync();

            //Return response
            return new BookGenreResponse(bookGenre);
        }
        catch (Exception e)
        {
            return new BookGenreResponse($"An error ocurred while saving the book_genre element: {e.Message}");
        }
    }

    
    public async Task<BookGenreResponse> DeleteAsync(int bookGenreId)
    {
        var existingBookGenre = await _bookGenreRepository.FindByBookGenreId(bookGenreId);
        if (existingBookGenre == null)
            return new BookGenreResponse("Book Genre not found.");

        try
        {
            _bookGenreRepository.Remove(existingBookGenre);
            await _unitOfWork.CompleteAsync();
            return new BookGenreResponse(existingBookGenre);
        }
        catch (Exception e)
        {
            return new BookGenreResponse($"An error ocurred while deleting the book: {e.Message}");
        }
    }
}