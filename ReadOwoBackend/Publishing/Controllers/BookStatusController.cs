using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookStatusController : ControllerBase
{
    private readonly IBookStatusService _bookStatusService;
    private readonly IMapper _mapper;
    
    public BookStatusController(IBookStatusService bookStatusService, IMapper mapper)
    {
        _bookStatusService = bookStatusService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<BookStatusResource>> GetAllAsync()
    {
        var bookStatuses = await _bookStatusService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BookStatus>, IEnumerable<BookStatusResource>>(bookStatuses);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<BookStatusResource> FindByIdAsync(int bookStatusId)
    {
        var bookStatus = await _bookStatusService.FindByIdAsync(bookStatusId);
        var resources = _mapper.Map<BookStatus, BookStatusResource>(bookStatus.Resource);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBookStatusResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var bookStatus = _mapper.Map<SaveBookStatusResource, BookStatus>(resource);

        var result = await _bookStatusService.SaveAsync(bookStatus);

        if (!result.Success)
            return BadRequest(result.Message);

        var bookStatusResource = _mapper.Map<BookStatus, BookStatusResource>(result.Resource);

        return Ok(bookStatusResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBookStatusResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var bookStatus = _mapper.Map<SaveBookStatusResource, BookStatus>(resource);
        var result = await _bookStatusService.UpdateAsync(id, bookStatus);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var bookStatusResource = _mapper.Map<BookStatus, BookStatusResource>(result.Resource);

        return Ok(bookStatusResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookStatusService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var bookStatusResource = _mapper.Map<BookStatus, BookStatusResource>(result.Resource);

        return Ok(bookStatusResource);
    }
}