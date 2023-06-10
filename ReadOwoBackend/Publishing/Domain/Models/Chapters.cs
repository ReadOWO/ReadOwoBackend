namespace ReadOwoBackend.Publishing.Domain.Models;

public class Chapters
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Document_content_url { get; set; }
    
    public int BookId { get; set; }
    
    public Book Book { get; set; }
}