using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class LanguageResponse : BaseResponse<Language>
{
    public LanguageResponse(string message) : base(message)
    {
    }

    public LanguageResponse(Language resource) : base(resource)
    {
    }
}