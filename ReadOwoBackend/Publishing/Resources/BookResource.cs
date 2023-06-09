using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Resources;

public class BookResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public BookStatusResource BookStatus { get; set; }
}