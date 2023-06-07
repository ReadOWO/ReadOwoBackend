using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> ListAsync();
    Task<IEnumerable<Genre>> ListByGenreIdAsync(int genreId);
    Task<GenreResponse> SaveAsync(Genre genre);
    Task<GenreResponse> UpdateAsync(int genreId, Genre genre);
    Task<GenreResponse> DeleteAsync(int genreId);
}