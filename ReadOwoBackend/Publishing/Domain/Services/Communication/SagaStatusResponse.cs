using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class SagaStatusResponse: BaseResponse<SagaStatus>
{
    public SagaStatusResponse(string message) : base(message)
    {
    }

    public SagaStatusResponse(SagaStatus resource) : base(resource)
    {
    }
}