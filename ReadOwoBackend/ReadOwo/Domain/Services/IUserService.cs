using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Domain.Services.Communication;

namespace ReadOwoBackend.ReadOwo.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<IEnumerable<User>> ListByCategoryIdAsync(int categoryId);
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int userId, User user);
    Task<UserResponse> DeleteAsync(int userId);
}