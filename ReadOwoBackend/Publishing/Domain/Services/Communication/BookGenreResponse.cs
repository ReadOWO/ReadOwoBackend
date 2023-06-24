using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services.Communication;

public class BookGenreResponse : BaseResponse<BookGenre>
{
    public BookGenreResponse(string message) : base(message)
    {
    }

    public BookGenreResponse(BookGenre resource) : base(resource)
    {
    }
}