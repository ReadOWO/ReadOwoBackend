namespace ReadOwoBackend.Publishing.Resources;

public class ChaptersResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Document_content_url { get; set; }
    public BookResource Book { get; set; }
}