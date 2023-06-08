using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SagaController : ControllerBase
{
    private readonly ISagaService _sagaService;
    private readonly IMapper _mapper;


    public SagaController(ISagaService sagaService, IMapper mapper)
    {
        _sagaService = sagaService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SagaResource>> GetAllAsync()
    {
        var sagas = await _sagaService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Saga>, IEnumerable<SagaResource>>(sagas);

        return resources;
    }
    [HttpGet("{id}")]
    public async Task<SagaResource> FindByIdAsync(int SagaId)
    {
        var sagas = await _sagaService.FindByIdAsync(SagaId);
        var resources = _mapper.Map<Saga, SagaResource>(sagas.Resource);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSagaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var saga = _mapper.Map<SaveSagaResource, Saga>(resource);

        var result = await _sagaService.SaveAsync(saga);

        if (!result.Success)
            return BadRequest(result.Message);

        var sagaResource = _mapper.Map<Saga, SagaResource>(result.Resource);

        return Ok(sagaResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSagaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var saga = _mapper.Map<SaveSagaResource, Saga>(resource);
        var result = await _sagaService.UpdateAsync(id, saga);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var sagaResource = _mapper.Map<Saga, SagaResource>(result.Resource);

        return Ok(sagaResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _sagaService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var sagaResource = _mapper.Map<Saga, SagaResource>(result.Resource);

        return Ok(sagaResource);
    }
}