namespace ReadOwoBackend.Publishing.Resources;

public class SagaResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public SagaStatusResource SagaStatus { get; set; }
}
