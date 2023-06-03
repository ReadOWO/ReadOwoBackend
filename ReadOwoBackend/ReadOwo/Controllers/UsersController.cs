using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Resources;
using ReadOwoBackend.ReadOwo.Services;

namespace ReadOwoBackend.ReadOwo.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

        return resources;
    } 
}