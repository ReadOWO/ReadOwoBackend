using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Domain.Repositories;
using ReadOwoBackend.ReadOwo.Domain.Services;
using ReadOwoBackend.ReadOwo.Domain.Services.Communication;

namespace ReadOwoBackend.ReadOwo.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _UserProfileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    
    public UserProfileService(IUserProfileRepository userProfileRepository, 
        IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _UserProfileRepository = userProfileRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserProfile>> ListAsync()
    {
        return await _UserProfileRepository.ListAsync();
    }

    public async Task<IEnumerable<UserProfile>> ListByUserIdAsync(int userId)
    {
        return await _UserProfileRepository.FindByUserIdAsync(userId);

    }

    public async Task<UserProfileResponse> SaveAsync(UserProfile userProfile)
    {
        var existingUser = await 
            _userRepository.FindByIdAsync(userProfile.UserId);
        if (existingUser == null)
            return new UserProfileResponse("Invalid User");
        
        var existingUserProfileWithName = await 
            _UserProfileRepository.FindByNameAsync(userProfile.Name);
        if (existingUserProfileWithName != null)
            return new UserProfileResponse("Profile name already exists.");
        try
        {
            await _UserProfileRepository.AddAsync(userProfile);
 
            await _unitOfWork.CompleteAsync();
            
            return new UserProfileResponse(userProfile);
        }
        catch (Exception e)
        {
            return new UserProfileResponse($"An error occurred while saving the profile: {e.Message}");
        }
    }

    public async Task<UserProfileResponse> UpdateAsync(int userProfileId, UserProfile userProfile)
    {
        var existingUserProfile = await 
            _UserProfileRepository.FindByIdAsync(userProfileId);
        
        if (existingUserProfile == null)
            return new UserProfileResponse("Profile not found.");
        
        var existingUser = await 
            _userRepository.FindByIdAsync(userProfile.UserId);
        if (existingUser == null)
            return new UserProfileResponse("Invalid User");
        var existingUserProfileWithName = await 
            _UserProfileRepository.FindByNameAsync(userProfile.Name);
        if (existingUserProfileWithName != null && 
            existingUserProfileWithName.Id != existingUserProfile.Id)
            return new UserProfileResponse("Profile name already exists.");
        
        existingUserProfile.Name = userProfile.Name;
        
        try
        {
            _UserProfileRepository.Update(existingUserProfile);
            await _unitOfWork.CompleteAsync();
            return new UserProfileResponse(existingUserProfile);
 }
        catch (Exception e)
        {
            return new UserProfileResponse($"An error occurred while updating the profile: {e.Message}");
        }
    }

    public async Task<UserProfileResponse> DeleteAsync(int userProfileId)
    {
        var existingUserProfile = await 
            _UserProfileRepository.FindByIdAsync(userProfileId);
        
        if (existingUserProfile == null)
            return new UserProfileResponse("Profile not found.");
 
        try
        {
            _UserProfileRepository.Remove(existingUserProfile);
            await _unitOfWork.CompleteAsync();
            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception e)
        {
            return new UserProfileResponse($"An error occurred while deleting the profile: {e.Message}");
        }
    }
}