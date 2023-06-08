using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class SagaResponse: BaseResponse<Saga>
{
    public SagaResponse(string message) : base(message)
    {
    }

    public SagaResponse(Saga resource) : base(resource)
    {
    }
}