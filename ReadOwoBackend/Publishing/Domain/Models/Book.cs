namespace ReadOwoBackend.Publishing.Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public int BookStatusId { get; set; }
    public BookStatus BookStatus { get; set; } 
}