namespace ReadOwoBackend.Publishing.Domain.Models;

public class Language
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    
    //Relationships
    public IList<Book> Books { get; set; } = new List<Book>();
}