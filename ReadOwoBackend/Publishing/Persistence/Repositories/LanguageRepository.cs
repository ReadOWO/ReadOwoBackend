using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class LanguageRepository : BaseRepository, ILanguageReposiroty
{
    public LanguageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Language>> ListAsync()
    {
        return await _context.Languages.ToListAsync();
    }

    public async Task AddAsync(Language language)
    {
        await _context.Languages.AddAsync(language);
    }

    public async Task<Language> FindByIdAsync(int id)
    {
        return await _context.Languages.FindAsync(id);
    }

    public void Update(Language language)
    {
        _context.Languages.Update(language);
    }

    public void Remove(Language language)
    {
        _context.Languages.Remove(language);
    }
}