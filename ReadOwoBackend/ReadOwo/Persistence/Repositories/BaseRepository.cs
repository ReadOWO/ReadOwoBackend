using ReadOwoBackend.ReadOwo.Persistence.Contexts;

namespace ReadOwoBackend.ReadOwo.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}