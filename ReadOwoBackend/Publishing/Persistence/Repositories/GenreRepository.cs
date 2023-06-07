using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class GenreRepository : BaseRepository, IGenreRepository
{
    public GenreRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Genre>> ListAsync()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task AddAsync(Genre genre)
    {
        await _context.Genres.AddAsync(genre);
    }

    public async Task<Genre> FindByIdAsync(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public void Update(Genre genre)
    {
        _context.Genres.Update(genre);
    }

    public void Remove(Genre genre)
    {
        _context.Genres.Remove(genre);
    }
}