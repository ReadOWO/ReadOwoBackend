using ReadOwoBackend.ReadOwo.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;

namespace ReadOwoBackend.Shared.Persistence.Repositories;

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