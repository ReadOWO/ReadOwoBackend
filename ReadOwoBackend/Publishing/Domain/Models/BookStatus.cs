namespace ReadOwoBackend.Publishing.Domain.Models;

public class BookStatus
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    //Relationships
    public IList<Book> Books { get; set; } = new List<Book>();
}