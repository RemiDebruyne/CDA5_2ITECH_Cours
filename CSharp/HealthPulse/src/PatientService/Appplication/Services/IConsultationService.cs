using ConsulationService.Appplication.Dtos;
using ConsulationService.Domain.Entities;

namespace ConsulationService.Appplication.Services;

public interface IConsultationService
{
    Task<IEnumerable<ConsultationResponseDto>> GetAllAsync();

    Task<ConsultationResponseDto?> GetByIdAsync(Guid id);

    Task<ConsultationResponseDto> CreateAsync(ConsultationRequestDto dto);

    Task<ConsultationResponseDto?> UpdateAsync(Guid id, ConsultationRequestDto dto);

    Task<bool> DeleteAsync(Guid id);

    Task<IEnumerable<Consultation>> GetByPatientIdAsync(Guid patientId);

    Task<CoutHoraireResponseDto?> GetCoutHoraire(Guid id);

}
