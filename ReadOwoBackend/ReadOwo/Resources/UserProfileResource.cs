namespace ReadOwoBackend.ReadOwo.Resources;

public class UserProfileResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserResource User { get; set; }
}