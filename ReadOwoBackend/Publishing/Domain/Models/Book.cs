namespace ReadOwoBackend.Publishing.Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public string PublishedAt { get; set; }
    public string ThumbnailUrl { get; set; }
    public int ProfileId { get; set; }
    public int BookStatusId { get; set; }
    public BookStatus BookStatus { get; set; }
    public int SagaId { get; set; }
    public Saga Saga { get; set; }
    
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    
    public IList<Chapters> Chapters { get; set; } = new List<Chapters>();
}