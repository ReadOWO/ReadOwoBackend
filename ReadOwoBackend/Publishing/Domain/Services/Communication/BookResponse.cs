using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class BookResponse : BaseResponse<Book>
{
    public BookResponse(string message) : base(message)
    {
    }
    
    public BookResponse(string resource): base(resource)
    {
    }
}