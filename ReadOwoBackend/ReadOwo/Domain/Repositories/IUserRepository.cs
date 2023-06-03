using ReadOwoBackend.ReadOwo.Domain.Models;

namespace ReadOwoBackend.ReadOwo.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    void Update(User user);
    void Remove(User user);
}