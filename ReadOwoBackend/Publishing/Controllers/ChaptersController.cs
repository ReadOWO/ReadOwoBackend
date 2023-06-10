using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class ChaptersController : ControllerBase
{
    private readonly IChaptersService _chaptersService;
    private readonly IMapper _mapper;


    public ChaptersController(IChaptersService chaptersService, IMapper mapper)
    {
        _chaptersService = chaptersService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ChaptersResource>> GetAllAsync()
    {
        var chapters = await _chaptersService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Chapters>, IEnumerable<ChaptersResource>>(chapters);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveChaptersResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var chapters = _mapper.Map<SaveChaptersResource, Chapters>(resource);
        var result = await _chaptersService.SaveAsync(chapters);
        if (!result.Success)
            return BadRequest(result.Message);
        var chaptersResource = _mapper.Map<Chapters, ChaptersResource>(result.Resource);
        return Ok(chaptersResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveChaptersResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var chapters = _mapper.Map<SaveChaptersResource, Chapters>(resource);
        var result = await _chaptersService.UpdateAsync(id, chapters);
        if (!result.Success)
            return BadRequest(result.Message);
        var chaptersResource = _mapper.Map<Chapters, ChaptersResource>(result.Resource);
        return Ok(chaptersResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _chaptersService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var chaptersResource = _mapper.Map<Chapters, ChaptersResource>(result.Resource);
        return Ok(chaptersResource);
    }
}