using ConsulationService.Appplication.Dtos;
using ConsulationService.Appplication.Services;
using ConsulationService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConsulationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultationController(IConsultationService service) : ControllerBase
{

    [HttpGet]

    public async Task<ActionResult<IEnumerable<ConsultationResponseDto>>> GetAll()
    {
        var consultations = await service.GetAllAsync();

        return Ok(consultations);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ConsultationResponseDto>> GetById(Guid id)
    {
        var consultation = await service.GetByIdAsync(id);

        if (consultation is null) return NotFound(new { message = $"Consultation avec l'ID {id} non trouvé" });

        return Ok(consultation);
    }

    [HttpGet("patient/{patientId:guid}")]
    public async Task<ActionResult<IEnumerable<ConsultationResponseDto>>> GetByPatientId(Guid patientId)
    {
        return Ok(await service.GetByPatientIdAsync(patientId));
    }

    [HttpGet("{id:guid}/cout-horaire")]
    public async Task<ActionResult<CoutHoraireResponseDto>> GetCoutHoraire(Guid id)
    {
        var coutHoraireDto = await service.GetCoutHoraire(id);


        if (coutHoraireDto is null) return NotFound(new { message = $"Consultation avec l'ID {id} non trouvé" });

        return Ok(coutHoraireDto);
    }

    [HttpPost]
    public async Task<ActionResult<ConsultationResponseDto>> Create([FromBody] ConsultationRequestDto consultationRequestion)
    {
        return Ok(await service.CreateAsync(consultationRequestion));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ConsultationResponseDto>> Create(
        [FromRoute] Guid id,
        [FromBody] ConsultationRequestDto consultationRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await service.UpdateAsync(id, consultationRequest);
        if (updated == null)
            return NotFound(new { message = $"Consultation avec l'ID {id} non trouvé" });

        return Ok(updated);
    }
}
