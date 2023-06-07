using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> ListAsync();
    Task AddAsync(Genre genre);
    Task<Genre> FindByIdAsync(int id);
    void Update(Genre genre);
    void Remove(Genre genre);
}