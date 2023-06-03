using ReadOwoBackend.ReadOwo.Domain.Repositories;
using ReadOwoBackend.ReadOwo.Persistence.Contexts;

namespace ReadOwoBackend.ReadOwo.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}