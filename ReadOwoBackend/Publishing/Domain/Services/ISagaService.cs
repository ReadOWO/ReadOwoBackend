using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface ISagaService
{
    Task<IEnumerable<Saga>> ListAsync();
    Task<SagaResponse> FindByIdAsync(int sagaId);
    Task<SagaResponse> SaveAsync(Saga saga);
    Task<SagaResponse> UpdateAsync(int sagaId, Saga saga);
    Task<SagaResponse> DeleteAsync(int sagaId);
}