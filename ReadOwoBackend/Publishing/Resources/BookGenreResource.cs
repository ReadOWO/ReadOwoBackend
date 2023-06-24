namespace ReadOwoBackend.Publishing.Resources;

public class BookGenreResource
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public BookResource Book { get; set; }
    public int GenreId { get; set; }
    public GenreResource Genre { get; set; }
}