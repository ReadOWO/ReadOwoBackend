using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class LanguageService :  ILanguageService
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
    {
        _languageRepository = languageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Language>> ListAsync()
    {
        return await _languageRepository.ListAsync();
    }

    public async Task<IEnumerable<Language>> ListByLanguageIdAsync(int languageId)
    {
        return await _languageRepository.ListAsync();
    }

    public async Task<LanguageResponse> SaveAsync(Language language)
    {
        try
        {
            await _languageRepository.AddAsync(language);
            await _unitOfWork.CompleteAsync();
            return new LanguageResponse(language);
        }
        catch (Exception e)
        {
            return new LanguageResponse($"An error occurred while saving the genre: {e.Message}");
            
        }
    }

 

    public async Task<LanguageResponse> UpdateAsync(int languageId, Language language)
    {
        var existingLanguage = await _languageRepository.FindByIdAsync(languageId);
        if (existingLanguage == null) return new LanguageResponse("Language not found.");
        existingLanguage.Name = language.Name;
        try
        {
            _languageRepository.Update(existingLanguage);
            await _unitOfWork.CompleteAsync();
            return new LanguageResponse(existingLanguage);
        }
        catch (Exception e)
        {
            return new LanguageResponse($"An error occurred whit updating the user: {e.Message}");
        }
    }

    public async Task<LanguageResponse> DeleteAsync(int languageId)
    {
        var existingLanguage = await _languageRepository.FindByIdAsync(languageId);
        if (existingLanguage == null)
            return new LanguageResponse("Language not found.");
        try
        {
            _languageRepository.Remove(existingLanguage);
            await _unitOfWork.CompleteAsync();
            return new LanguageResponse(existingLanguage);
        }
        catch (Exception e)
        {
            return new LanguageResponse($"An error occurred while deleting the language: {e.Message}");
        }
    }
}