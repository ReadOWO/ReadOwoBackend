using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface IChaptersService
{
    Task<IEnumerable<Chapters>> ListAsync();
    Task<IEnumerable<Chapters>> ListByChaptersIdAsync(int chaptersId);
    Task<ChaptersResponse> SaveAsync(Chapters chapters);
    Task<ChaptersResponse> UpdateAsync(int chaptersId, Chapters chapters);
    Task<ChaptersResponse> DeleteAsync(int chaptersId);
}