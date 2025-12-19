using EnergyApi.Application.Dto;
using EnergyApi.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnergyApi.Api.Controller;
[Route("api/energies")]
[ApiController]
public class EnergyController(IEnergyService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<EnergyResponseDto>>> Get()
    {
        return Ok(await service.GetAllAsync());
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EnergyResponseDto>> Get(int id)
    {
        EnergyResponseDto? energyDto = await service.GetEnergyByIdAsync(id);

        if (energyDto is null) return NotFound();

        return Ok(energyDto);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<ActionResult<EnergyResponseDto>> Post([FromBody] CreateEnergyDto createEnergyDto)
    {
        EnergyResponseDto createdEnergy = await service.AddEnergyAsync(createEnergyDto);

        return Ok(createdEnergy);
    }
}
