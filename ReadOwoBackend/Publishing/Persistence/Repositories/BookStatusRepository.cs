using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class BookStatusRepository : BaseRepository, IBookStatusRepository
{
    public BookStatusRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<BookStatus>> ListAsync()
    {
        return await _context.BookStatuses.ToListAsync();
    }
    public async Task AddAsync(BookStatus bookStatus)
    {
        await _context.BookStatuses.AddAsync(bookStatus);
    }
    public async Task<BookStatus> FindByIdAsync(int id)
    {
        return await _context.BookStatuses.FindAsync(id);
    }
    public void Update(BookStatus bookStatus)
    {
        _context.BookStatuses.Update(bookStatus);
    }
    public void Remove(BookStatus bookStatus)
    {
        _context.BookStatuses.Remove(bookStatus);
    }
}