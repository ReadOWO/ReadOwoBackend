using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface IBookGenreRepository
{
    Task<IEnumerable<BookGenre>> ListAsync();
    Task AddAsync(BookGenre bookGenre);
    Task<BookGenre> FindByBookGenreId(int id);
    void Remove(BookGenre bookGenre);
}