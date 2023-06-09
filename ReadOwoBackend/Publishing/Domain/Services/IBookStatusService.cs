using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IBookStatusService
{
    Task<IEnumerable<BookStatus>> ListAsync();
    Task<BookStatus> FindByIdAsync(int bookStatusId);
    Task<BookStatus> SaveAsync(BookStatus bookStatus);
    Task<BookStatus> UpdateAsync(int bookStatusId, BookStatus bookStatus);
    Task<BookStatus> DeleteAsync(int bookStatusId);
}