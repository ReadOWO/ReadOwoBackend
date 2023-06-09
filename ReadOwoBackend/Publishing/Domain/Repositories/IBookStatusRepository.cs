using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface IBookStatusRepository
{
    Task<IEnumerable<BookStatus>> ListAsync();
    Task AddAsync(BookStatus bookStatus);
    Task<BookStatus> FindByIdAsync(int id);
    void Update(BookStatus bookStatus);
    void Remove(BookStatus bookStatus);
}