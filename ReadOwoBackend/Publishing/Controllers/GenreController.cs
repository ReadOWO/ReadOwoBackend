using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    private readonly IMapper _mapper;


    public GenreController(IGenreService genreService, IMapper mapper)
    {
        _genreService = genreService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GenreResource>> GetAllAsync()
    {
        var genres = await _genreService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveGenreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var genre = _mapper.Map<SaveGenreResource, Genre>(resource);
        var result = await _genreService.SaveAsync(genre);
        if (!result.Success)
            return BadRequest(result.Message);
        var genreResource = _mapper.Map<Genre, GenreResource>(result.Resource);
        return Ok(genreResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveGenreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var genre = _mapper.Map<SaveGenreResource, Genre>(resource);
        var result = await _genreService.UpdateAsync(id, genre);
        if (!result.Success)
            return BadRequest(result.Message);
        var genreResource = _mapper.Map<Genre, GenreResource>(result.Resource);
        return Ok(genreResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _genreService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var genreResource = _mapper.Map<Genre, GenreResource>(result.Resource);
        return Ok(genreResource);
    }
}