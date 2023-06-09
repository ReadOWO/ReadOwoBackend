using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> ListAsync();
    Task<BookResponse> FindByIdAsync(int bookId);
    Task<BookResponse> SaveAsync(Book book);
    Task<BookResponse> UpdateAsync(int bookId, Book book);
    Task<BookResponse> DeleteAsync(int bookId);
}