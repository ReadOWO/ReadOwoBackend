using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface ISagaRepository
{
    Task<IEnumerable<Saga>> ListAsync();
    Task AddAsync(Saga saga);
    Task<Saga> FindByIdAsync(int id);
    void Update(Saga saga);
    void Remove(Saga saga);
}