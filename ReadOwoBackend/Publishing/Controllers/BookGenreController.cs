using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookGenreController : ControllerBase
{
    private readonly IBookGenreService _bookGenreService;
    private readonly IMapper _mapper;

    public BookGenreController(IBookGenreService bookGenreService, IMapper mapper)
    {
        _bookGenreService = bookGenreService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BookGenreResource>> GetAllAsync()
    {
        var bookGenres = await _bookGenreService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BookGenre>, IEnumerable<BookGenreResource>>(bookGenres);
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<BookGenreResource> FindByIdAsync(int bookGenreId)
    {
        var bookGenres = await _bookGenreService.FindByIdAsync(bookGenreId);
        var resources = _mapper.Map<BookGenre, BookGenreResource>(bookGenres.Resource);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBookGenreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var bookGenre = _mapper.Map<SaveBookGenreResource, BookGenre>(resource);
        var result = await _bookGenreService.SaveAsync(bookGenre);
        if (!result.Success)
            return BadRequest(result.Message);
        var bookGenreResource = _mapper.Map<BookGenre, BookGenreResource>(result.Resource);
        return Ok(bookGenreResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookGenreService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var bookGenreResource = _mapper.Map<BookGenre, BookGenreResource>(result.Resource);
        return Ok(bookGenreResource);
    }
}