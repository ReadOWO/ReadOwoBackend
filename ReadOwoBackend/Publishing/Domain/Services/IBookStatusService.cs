using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IBookStatusService
{
    Task<IEnumerable<BookStatus>> ListAsync();
    Task<BookStatusResponse> FindByIdAsync(int bookStatusId);
    Task<BookStatusResponse> SaveAsync(BookStatus bookStatus);
    Task<BookStatusResponse> UpdateAsync(int bookStatusId, BookStatus bookStatus);
    Task<BookStatusResponse> DeleteAsync(int bookStatusId);
}