using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.Shared.Domain.Services.Communication;

namespace ReadOwoBackend.ReadOwo.Domain.Services.Communication;

public class UserResponse: BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}