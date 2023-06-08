using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class SagaStatusRepository : BaseRepository, ISagaStatusRepository
{
    public SagaStatusRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<SagaStatus>> ListAsync()
    {
        return await _context.SagaStatuses.ToListAsync();
    }
    public async Task AddAsync(SagaStatus sagaStatus)
    {
        await _context.SagaStatuses.AddAsync(sagaStatus);
    }
    public async Task<SagaStatus> FindByIdAsync(int id)
    {
        return await _context.SagaStatuses.FindAsync(id);
    }
    public void Update(SagaStatus sagaStatus)
    {
        _context.SagaStatuses.Update(sagaStatus);
    }
    public void Remove(SagaStatus sagaStatus)
    {
        _context.SagaStatuses.Remove(sagaStatus);
    }
}