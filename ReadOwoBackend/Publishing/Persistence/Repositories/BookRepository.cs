using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

namespace ReadOwoBackend.Publishing.Persistence.Repositories;

public class BookRepository : BaseRepository, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Book>> ListAsync()
    {
        return await _context.Books
            .Include(bs => bs.BookStatus)
            .Include(s=>s.Saga)
            .Include(ss=>ss.Saga.SagaStatus)
            .Include(l=>l.Language)
            .ToListAsync();
    }
    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
    }
    public async Task<Book> FindByIdAsync(int bookId)
    {
        return await _context.Books
            .Include(bs => bs.BookStatus)
            .Include(s=>s.Saga)
            .Include(ss=>ss.Saga.SagaStatus)
            .Include(l=>l.Language)
            .FirstOrDefaultAsync(s=>s.Id == bookId);
    }
    public void Update(Book book)
    {
        _context.Books.Update(book);
    }
    public void Remove(Book book)
    {
        _context.Books.Remove(book);
    }
}