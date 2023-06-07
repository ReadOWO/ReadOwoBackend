using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.ReadOwo.Persistence.Repositories;

public class UserProfileRepository : BaseRepository, IUserProfileRepository
{
    public UserProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserProfile>> ListAsync()
    {
        return await _context.Profiles
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(UserProfile userProfile)
    {
        await _context.Profiles.AddAsync(userProfile);
    }

    public async Task<UserProfile> FindByIdAsync(int userProfileId)
    {
        return await _context.Profiles
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == userProfileId);
    }

    public async Task<UserProfile> FindByNameAsync(string name)
    {
        return await _context.Profiles
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Name== name);
    }

    public async Task<IEnumerable<UserProfile>> FindByUserIdAsync(int userId)
    {
        return await _context.Profiles
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(UserProfile userProfile)
    {
        _context.Profiles.Update(userProfile);
    }

    public void Remove(UserProfile userProfile)
    {
        _context.Profiles.Remove(userProfile);
    }
}