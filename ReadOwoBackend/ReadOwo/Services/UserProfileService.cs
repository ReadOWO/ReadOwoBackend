using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Domain.Repositories;
using ReadOwoBackend.ReadOwo.Domain.Services;
using ReadOwoBackend.ReadOwo.Domain.Services.Communication;

namespace ReadOwoBackend.ReadOwo.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    
    public UserProfileService(IUserProfileRepository userProfileRepository, 
        IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _userProfileRepository = userProfileRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserProfile>> ListAsync()
    {
        return await _userProfileRepository.ListAsync();
    }

    public async Task<IEnumerable<UserProfile>> ListByUserIdAsync(int userId)
    {
        return await _userProfileRepository.FindByUserIdAsync(userId);

    }

    public async Task<UserProfileResponse> SaveAsync(UserProfile userProfile)
    {
        var existingUser = await 
            _userRepository.FindByIdAsync(userProfile.UserId);
        if (existingUser == null)
            return new UserProfileResponse("Invalid User");
        
        var existingUserProfileWithName = await 
            _userProfileRepository.FindByNameAsync(userProfile.Name);
        if (existingUserProfileWithName != null)
            return new UserProfileResponse("Profile name already exists.");
        try
        {
            await _userProfileRepository.AddAsync(userProfile);
 
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
            _userProfileRepository.FindByIdAsync(userProfileId);
        
        if (existingUserProfile == null)
            return new UserProfileResponse("Profile not found.");
        
        var existingUser = await 
            _userRepository.FindByIdAsync(userProfile.UserId);
        if (existingUser == null)
            return new UserProfileResponse("Invalid User");
        var existingUserProfileWithName = await 
            _userProfileRepository.FindByNameAsync(userProfile.Name);
        if (existingUserProfileWithName != null && 
            existingUserProfileWithName.Id != existingUserProfile.Id)
            return new UserProfileResponse("Profile name already exists.");
        
        existingUserProfile.Name = userProfile.Name;
        
        try
        {
            _userProfileRepository.Update(existingUserProfile);
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
            _userProfileRepository.FindByIdAsync(userProfileId);
        
        if (existingUserProfile == null)
            return new UserProfileResponse("Profile not found.");
 
        try
        {
            _userProfileRepository.Remove(existingUserProfile);
            await _unitOfWork.CompleteAsync();
            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception e)
        {
            return new UserProfileResponse($"An error occurred while deleting the profile: {e.Message}");
        }
    }
}