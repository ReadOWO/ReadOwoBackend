using ReadOwoBackend.Publishing.Domain.Models;

namespace ReadOwoBackend.Publishing.Domain.Repositories;

public interface ILanguageRepository
{
    Task<IEnumerable<Language>> ListAsync();
    Task AddAsync(Language language);
    Task<Language> FindByIdAsync(int id);
    void Update(Language language);
    void Remove(Language language);
}