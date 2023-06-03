using ReadOwoBackend.Shared.Persistence.Contexts;

namespace ReadOwoBackend.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}