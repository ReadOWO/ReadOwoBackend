using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class ChaptersResponse : BaseResponse<Chapters>
{
    public ChaptersResponse(string message) : base(message)
    {
    }

    public ChaptersResponse(Chapters resource) : base(resource)
    {
    }
}