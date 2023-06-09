using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Resources;

public class BookResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public string PublishedAt { get; set; }
    public string ThumbnailUrl { get; set; }
    public int ProfileId { get; set; }
    public BookStatusResource BookStatus { get; set; }
    public SagaResource Saga { get; set; }
    public LanguageResource Language { get; set; }
}