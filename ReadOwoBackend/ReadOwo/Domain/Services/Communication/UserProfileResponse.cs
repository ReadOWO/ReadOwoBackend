using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.ReadOwo.Domain.Services.Communication;

public class UserProfileResponse : BaseResponse<UserProfile>
{
    public UserProfileResponse(string message) : base(message)
    {
    }

    public UserProfileResponse(UserProfile resource) : base(resource)
    {
    }
}