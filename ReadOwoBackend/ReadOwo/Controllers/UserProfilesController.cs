using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Domain.Services;
using ReadOwoBackend.ReadOwo.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.ReadOwo.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserProfilesController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IMapper _mapper;
    
    public UserProfilesController(IUserProfileService userProfileService, IMapper mapper)
    {
        _userProfileService = userProfileService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
    {
        var userProfile = await _userProfileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<UserProfile>, 
            IEnumerable<UserProfileResource>>(userProfile);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var userProfile = _mapper.Map<SaveUserProfileResource,
            UserProfile>(resource);
        var result = await _userProfileService.SaveAsync(userProfile);
        if (!result.Success)
            return BadRequest(result.Message);
        var userProfileResource = _mapper.Map<UserProfile,
            UserProfileResource>(result.Resource);
        return Ok(userProfileResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveUserProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var userProfile = _mapper.Map<SaveUserProfileResource, 
            UserProfile>(resource);
        var result = await _userProfileService.UpdateAsync(id, userProfile);
        if (!result.Success)
            return BadRequest(result.Message);
        var userProfileResource = _mapper.Map<UserProfile, 
            UserProfileResource>(result.Resource);
        return Ok(userProfileResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userProfileService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var userProfileResource = _mapper.Map<UserProfile, 
            UserProfileResource>(result.Resource);
        return Ok(userProfileResource);
    }
}