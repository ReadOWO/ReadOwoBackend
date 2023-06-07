using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Domain.Services.Communication;

namespace ReadOwoBackend.ReadOwo.Domain.Services;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task<IEnumerable<UserProfile>> ListByUserIdAsync(int userId);
    Task<UserProfileResponse> SaveAsync(UserProfile userProfile);
    Task<UserProfileResponse> UpdateAsync(int userProfileId, UserProfile userProfile);
    Task<UserProfileResponse> DeleteAsync(int userProfileId);
}