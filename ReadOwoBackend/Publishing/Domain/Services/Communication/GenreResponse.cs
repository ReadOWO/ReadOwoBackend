using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class GenreResponse: BaseResponse<Genre>
{
    public GenreResponse(string message) : base(message)
    {
    }

    public GenreResponse(Genre resource) : base(resource)
    {
    }
}