using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class ChaptersRepository : BaseRepository, IChaptersRepository
{
    public ChaptersRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Chapters>> ListAsync()
    {
        return await _context.Chapters.ToListAsync();
    }

    public async Task AddAsync(Chapters chapters)
    {
        await _context.Chapters.AddAsync(chapters);
    }

    public async Task<Chapters> FindByIdAsync(int id)
    {
        return await _context.Chapters.FindAsync(id);
    }

    public void Update(Chapters chapters)
    {
        _context.Chapters.Update(chapters);
    }

    public void Remove(Chapters chapters)
    {
        _context.Chapters.Remove(chapters);
    }
}