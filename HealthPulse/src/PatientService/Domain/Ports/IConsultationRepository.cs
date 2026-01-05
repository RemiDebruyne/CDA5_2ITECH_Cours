using ConsulationService.Domain.Entities;

namespace ConsulationService.Domain.Ports;

public interface IConsultationRepository
{
    Task<IEnumerable<Consultation>> GetAllAsync();
    Task<Consultation?> GetByIdAsync(Guid id);
    Task<Consultation> CreateAsync(Consultation consultation);
    Task<Consultation?> UpdateAsync(Guid id, Consultation consultation);
    Task<bool> DeleteAsync(Guid id);

    Task<IEnumerable<Consultation>> GetAllByPatientIdAsync(Guid id);
}
