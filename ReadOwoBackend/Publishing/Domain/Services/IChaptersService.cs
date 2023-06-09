using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IChaptersService
{
    Task<IEnumerable<Chapters>> ListAsync();
    Task AddAsync(Chapters chapters);
    Task<Chapters> FindByIdAsync(int id);
    void Update(Chapters  chapters);
    void Remove(Chapters  chapters);
}