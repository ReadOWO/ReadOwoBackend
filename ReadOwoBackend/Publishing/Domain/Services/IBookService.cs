using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> ListAsync();
    Task<Book> FindByIdAsync(int bookId);
    Task<Book> SaveAsync(Book book);
    Task<Book> UpdateAsync(int bookId, Book book);
    Task<Book> DeleteAsync(int bookId);
}