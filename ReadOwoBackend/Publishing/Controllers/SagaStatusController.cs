using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Resources;
using ReadOwoBackend.Shared.Extensions;

namespace ReadOwoBackend.Publishing.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SagaStatusController : ControllerBase
{
    private readonly ISagaStatusService _sagaStatusService;
    private readonly IMapper _mapper;

    public SagaStatusController(ISagaStatusService sagaStatusService, IMapper mapper)
    {
        _sagaStatusService = sagaStatusService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<SagaStatusResource>> GetAllAsync()
    {
        var sagaStatuses = await _sagaStatusService.ListAsync();
        var resources = _mapper.Map<IEnumerable<SagaStatus>, IEnumerable<SagaStatusResource>>(sagaStatuses);

        return resources;

    }
    [HttpGet("{id}")]
    public async Task<SagaStatusResource> FindByIdAsync(int SagaStatusId)
    {
        var sagaStatus = await _sagaStatusService.FindByIdAsync(SagaStatusId);
        var resources = _mapper.Map<SagaStatus, SagaStatusResource>(sagaStatus.Resource);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSagaStatusResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var sagaStatus = _mapper.Map<SaveSagaStatusResource, SagaStatus>(resource);

        var result = await _sagaStatusService.SaveAsync(sagaStatus);

        if (!result.Success)
            return BadRequest(result.Message);

        var sagaStatusResource = _mapper.Map<SagaStatus, SagaStatusResource>(result.Resource);

        return Ok(sagaStatusResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSagaStatusResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var sagaStatus = _mapper.Map<SaveSagaStatusResource, SagaStatus>(resource);
        var result = await _sagaStatusService.UpdateAsync(id, sagaStatus);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var sagaStatusResource = _mapper.Map<SagaStatus, SagaStatusResource>(result.Resource);

        return Ok(sagaStatusResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _sagaStatusService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var sagaStatusResource = _mapper.Map<SagaStatus, SagaStatusResource>(result.Resource);

        return Ok(sagaStatusResource);
    }
}