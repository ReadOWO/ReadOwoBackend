using ReadOwoBackend.ReadOwo.Domain.Models;

namespace ReadOwoBackend.ReadOwo.Domain.Repositories;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task AddAsync(UserProfile userProfile);
    Task<UserProfile> FindByIdAsync(int userProfileId);
    Task<UserProfile> FindByNameAsync(string name);
    Task<IEnumerable<UserProfile>> FindByUserIdAsync(int userId);
    void Update(UserProfile userProfile);
    void Remove(UserProfile userProfile);
}