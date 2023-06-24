using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IBookGenreService
{
    Task<IEnumerable<BookGenre>> ListAsync();
    Task<BookGenreResponse> FindByIdAsync(int id);
    Task<BookGenreResponse> SaveAsync(BookGenre bookGenre);
    Task<BookGenreResponse> DeleteAsync(int bookGenreId);
}