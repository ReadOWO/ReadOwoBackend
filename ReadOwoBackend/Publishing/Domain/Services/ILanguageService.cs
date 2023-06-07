using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;

namespace ReadOwoBackend.Publishing.Domain.Services;

public interface ILanguageService
{
    Task<IEnumerable<Language>> ListAsync();
    Task<IEnumerable<Language>> ListByLanguageIdAsync(int languageId);
    Task<LanguageResponse> SaveAsync(Language language);
    Task<LanguageResponse> UpdateAsync(int languageId);
    Task<LanguageResponse> DeleteAsync(int languageId);
}