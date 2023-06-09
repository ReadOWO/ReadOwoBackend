using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class BookStatusResponse : BaseResponse<BookStatus>
{
    public BookStatusResponse(string message): base(message){}
    
    public BookStatusResponse(BookStatus resource): base(resource){}
}