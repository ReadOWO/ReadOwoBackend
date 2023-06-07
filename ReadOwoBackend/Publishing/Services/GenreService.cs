using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.ReadOwo.Domain.Repositories;

namespace ReadOwoBackend.Publishing.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;

    

public async Task<IEnumerable<Genre>> ListAsync()
    {
        return await _genreRepository.ListAsync();
    }

    public async Task<IEnumerable<Genre>> ListByGenreIdAsync(int genreId)
    {
        return await _genreRepository.ListAsync();
    }

    public async Task<GenreResponse> SaveAsync(Genre genre)
    {
        try
        {
            await _genreRepository.AddAsync(genre);
            await _unitOfWork.CompleteAsync();
            return new GenreResponse(genre);
        }
        catch (Exception e)
        {
            return new GenreResponse($"An error occurred while saving the genre: {e.Message}");
        }
    }

    public async Task<GenreResponse> UpdateAsync(int genreId, Genre genre)
    {
        var existingGenre = await _genreRepository.FindByIdAsync(genreId);
        if (existingGenre == null)
            return new GenreResponse("Genre not found.");
        existingGenre.Name = genre.Name;
        try
        {
            _genreRepository.Update(existingGenre);
            await _unitOfWork.CompleteAsync();
            return new GenreResponse(existingGenre);
        }
        catch (Exception e)
        {
            return new GenreResponse($"An error occurred while updating the user:{e.Message}");
        }
    }

    public async Task<GenreResponse> DeleteAsync(int genreId)
    {
        var existingGenre = await _genreRepository.FindByIdAsync(genreId);
        if (existingGenre == null)
            return new GenreResponse("Genre not found.");
        try
        {
            _genreRepository.Remove(existingGenre);
            await _unitOfWork.CompleteAsync();
            return new GenreResponse(existingGenre);
        }
        catch (Exception e)
        {
            return new GenreResponse($"An error occurred while deleting the genre: {e.Message}");
        }
    }
}