namespace ReadOwoBackend.ReadOwo.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}