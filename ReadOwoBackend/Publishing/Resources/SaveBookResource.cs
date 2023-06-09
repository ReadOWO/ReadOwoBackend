namespace ReadOwoBackend.Publishing.Resources;

public class SaveBookResource
{
    public string Title { get; set; }
    
    public string Synopsis { get; set; }
    
    public string PublishedAt { get; set; }
    
    public string ThumbnailUrl { get; set; }
    
    public int ProfileId { get; set; }
    
    public int BookStatusId { get; set; }
    
    public int SagaId { get; set; }
    
    public int LanguageId { get; set; }
}