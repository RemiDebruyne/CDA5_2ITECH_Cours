using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks.Dataflow;
using WasteApi.Application.Dto;
using WasteApi.Application.Services;

namespace WasteApi.Api.Controller;
[Route("api/wastes")]
[ApiController]
public class WasteController(IWasteService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<WasteResponseDto>>> GetAll()
    {
        return Ok(await service.GetAllAsync());
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WasteResponseDto>> Get(int id)
    {
        WasteResponseDto? wasteResponseDto = await service.GetByIdAsync(id);

        if (wasteResponseDto is null) return NotFound();

        return Ok(wasteResponseDto);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<ActionResult<WasteResponseDto>> Post([FromBody] CreateWasteDto createWasteDto)
    {
        WasteResponseDto wasteResponseDto = await service.AddAsync(createWasteDto);

        return Ok(wasteResponseDto);
    }

    [HttpPatch]
    public async Task<ActionResult> Patch([FromBody] UpdateWasteDto updateWasteDto)
    {
        await service.UpdateAsync(updateWasteDto);

        return NoContent();
    }

}
