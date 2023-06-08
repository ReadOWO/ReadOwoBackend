namespace ReadOwoBackend.Publishing.Domain.Models;

public class SagaStatus
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    // Relationships
    
    public IList<Saga> Sagas { get; set; } = new List<Saga>();
}