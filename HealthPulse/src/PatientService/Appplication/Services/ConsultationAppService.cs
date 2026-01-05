using ConsulationService.Appplication.Dtos;
using ConsulationService.Appplication.Mappers;
using ConsulationService.Domain.Entities;
using ConsulationService.Domain.Ports;
using ConsulationService.Infrastructure.Repository;

namespace ConsulationService.Appplication.Services;

public class ConsultationAppService(IConsultationRepository repository) : IConsultationService
{
    public async Task<ConsultationResponseDto> CreateAsync(ConsultationRequestDto dto)
    {

        var consultation = await repository.CreateAsync(ConsultationMapper.ToEntity(dto));

        return ConsultationMapper.ToConsultationDto(consultation);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ConsultationResponseDto>> GetAllAsync()
    {
        var consultations = await repository.GetAllAsync();
        return ConsultationMapper.ToConsultationResponseDtoList(consultations);
    }

    public async Task<ConsultationResponseDto?> GetByIdAsync(Guid id)
    {
        var consultation = await repository.GetByIdAsync(id);
        return consultation != null ? ConsultationMapper.ToConsultationDto(consultation) : null;
    }

    public async Task<IEnumerable<Consultation>> GetByPatientIdAsync(Guid patientId)
    {
        return await repository.GetAllByPatientIdAsync(patientId);
    }

    public async Task<ConsultationResponseDto?> UpdateAsync(Guid id, ConsultationRequestDto dto)
    {
        var consultation = ConsultationMapper.ToEntity(dto);
        var updated = await repository.UpdateAsync(id, consultation);
        return updated != null ? ConsultationMapper.ToConsultationDto(updated) : null;
    }

    public async Task<CoutHoraireResponseDto?> GetCoutHoraire(Guid id)
    {
        Consultation? consultation = await repository.GetByIdAsync(id);

        if (consultation != null) return null;

        return ConsultationMapper.ToCoutHoraireDto(consultation!);
    }
}
