using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface ISagaStatusRepository
{
    Task<IEnumerable<SagaStatus>> ListAsync();
    Task AddAsync(SagaStatus sagaStatus);
    Task<SagaStatus> FindByIdAsync(int id);
    void Update(SagaStatus sagaStatus);
    void Remove(SagaStatus sagaStatus);
}