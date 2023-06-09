using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> ListAsync();
    Task AddAsync(Book book);
    Task<Book> FindByIdAsync(int id);
    void Update(Book book);
    void Remove(Book book);
}