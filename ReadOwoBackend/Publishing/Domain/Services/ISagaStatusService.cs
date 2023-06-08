using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface ISagaStatusService
{
    Task<IEnumerable<SagaStatus>> ListAsync();
    Task<SagaStatusResponse> FindByIdAsync(int sagaStatusId);
    Task<SagaStatusResponse> SaveAsync(SagaStatus sagaStatus);
    Task<SagaStatusResponse> UpdateAsync(int sagaStatusId, SagaStatus sagaStatus);
    Task<SagaStatusResponse> DeleteAsync(int sagaStatusId);
}