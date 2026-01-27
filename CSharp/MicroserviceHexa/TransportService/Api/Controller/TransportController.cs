using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportApi.Application.Dto;
using TransportApi.Application.Services;

namespace TransportApi.Api.Controller;
[Route("api/transports")]
[ApiController]
public class TransportController(ITransportService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TransportResponseDto>>> Get()
    {
        return Ok(await service.GetAllAsync());
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TransportResponseDto>> Get(int id)
    {
        TransportResponseDto? transportDto = await service.GetByIdAsync(id);

        if (transportDto is null) return NotFound();

        return Ok(transportDto);
    }

    [HttpGet("{id}/emission")]
    public async Task<ActionResult<int>> GetEmission(int transportId)
    {
        int emission = await service.GetEmissionByTransport(transportId);

        return Ok(emission);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<ActionResult<TransportResponseDto>> Post([FromBody] CreateTransportDto createEnergyDto)
    {
        TransportResponseDto createdEnergy = await service.AddAsync(createEnergyDto);

        return Ok(createdEnergy);
    }

    [HttpPatch]
    public async Task<ActionResult> Patch([FromBody] UpdateTransportDto updateTransportDto)
    {
        await service.UpdateAsync(updateTransportDto);

        return NoContent();
    }

}
