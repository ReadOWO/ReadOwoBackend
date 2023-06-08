using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class SagaRepository : BaseRepository, ISagaRepository
{
    public SagaRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Saga>> ListAsync()
    {
        return await _context.Sagas
            .Include(ss=>ss.SagaStatus)
            .ToListAsync();
    }
    public async Task AddAsync(Saga saga)
    {
        await _context.Sagas.AddAsync(saga);
    }
    public async Task<Saga> FindByIdAsync(int sagaId)
    {
        return await _context.Sagas
            .Include(ss=>ss.SagaStatus )
            .FirstOrDefaultAsync(s=>s.Id == sagaId);
    }
    public void Update(Saga saga)
    {
        _context.Sagas.Update(saga);
    }
    public void Remove(Saga saga)
    {
        _context.Sagas.Remove(saga);
    }
}