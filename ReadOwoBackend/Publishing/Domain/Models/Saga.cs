namespace ReadOwoBackend.Publishing.Domain.Models;

public class Saga
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Synopsis { get; set; }
    
    public int SagaStatusId { get; set; }
    public SagaStatus SagaStatus { get; set; }
    
    public IList<Book> Books { get; set; } = new List<Book>();
}