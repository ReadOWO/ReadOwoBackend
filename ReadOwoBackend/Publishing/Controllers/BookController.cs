using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController: ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BookResource>> GetAllAsync()
    {
        var books = await _bookService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource >> (books);

        return resources;
    }

    [HttpGet("{id}")]
    public async Task<BookResource> FindByIdAsync(int bookId)
    {
        var books = await _bookService.FindByIdAsync(bookId);
        var resources = _mapper.Map<Book, BookResource> (books.Resource);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBookResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var book = _mapper.Map<SaveBookResource, Book>(resource);
        var result = await _bookService.SaveAsync(book);

        if (!result.Success)
            return BadRequest(result.Message);

        var bookResource = _mapper.Map<Book, BookResource>(result.Resource);

        return Ok(bookResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBookResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var book = _mapper.Map<SaveBookResource, Book>(resource);
        var result = await _bookService.UpdateAsync(id, book);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var bookResource = _mapper.Map<Book, BookResource>(result.Resource);

        return Ok(bookResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var bookResource = _mapper.Map<Book, BookResource>(result.Resource);

        return Ok(bookResource);
    }
}