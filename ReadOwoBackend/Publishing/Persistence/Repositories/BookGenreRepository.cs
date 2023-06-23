using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class BookGenreRepository : BaseRepository, IBookGenreRepository
{
    public BookGenreRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<BookGenre>> ListAsync()
    {
        return await _context.BookGenres
            .Include(b => b.Book)
            .Include(b => b.Book.BookStatus)
            .Include(b => b.Book.Saga)
            .Include(b => b.Book.Saga.SagaStatus)
            .Include(b => b.Book.Language)
            .Include(g => g.Genre)
            .ToListAsync();
    }

    public async Task AddAsync(BookGenre bookGenre)
    {
        await _context.BookGenres.AddAsync(bookGenre);
    }

    public async Task<BookGenre> FindByBookGenreId(int id)
    {
        return await _context.BookGenres
            .Include(b => b.Book)
            .Include(b => b.Book.BookStatus)
            .Include(b => b.Book.Saga)
            .Include(b => b.Book.Saga.SagaStatus)
            .Include(b => b.Book.Language)
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(bg => bg.Id == id);
    }

    public void Remove(BookGenre bookGenre)
    {
        _context.BookGenres.Remove(bookGenre);
    }
}