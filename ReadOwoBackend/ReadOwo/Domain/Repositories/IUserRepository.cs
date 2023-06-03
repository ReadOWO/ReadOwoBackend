using ReadOwoBackend.ReadOwo.Domain.Models;

namespace ReadOwoBackend.ReadOwo.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User category);
    Task<User> FindByIdAsync(int id);
    void Update(User category);
    void Remove(User category);
}