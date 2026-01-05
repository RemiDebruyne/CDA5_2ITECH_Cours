using ConsulationService.Domain.Entities;
using ConsulationService.Domain.Ports;

namespace ConsulationService.Infrastructure.Repository;

public class InMemoryConsultationRepository : IConsultationRepository
{
    private readonly List<Consultation> _consultations = [];

    public Task<Consultation> CreateAsync(Consultation consultation)
    {
        consultation.Id = Guid.NewGuid();

        _consultations.Add(consultation);

        return Task.FromResult(consultation);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var consultation = _consultations.FirstOrDefault(c => c.Id == id);

        if (consultation is null) return Task.FromResult(false);

        _consultations.Remove(consultation);

        return Task.FromResult(true);
    }

    public Task<IEnumerable<Consultation>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Consultation>>(_consultations);
    }

    public Task<Consultation?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_consultations.FirstOrDefault((c) => c.Id == id));
    }

    public Task<Consultation?> UpdateAsync(Guid id, Consultation consultation)
    {
        var existing = _consultations.FirstOrDefault(p => p.Id == id);
        if (existing == null) return Task.FromResult<Consultation?>(null);

        existing.DureeMinutes = consultation.DureeMinutes;
        existing.Motif = consultation.Motif;
        existing.DateConsultation = consultation.DateConsultation;

        return Task.FromResult<Consultation?>(existing);
    }

    public Task<IEnumerable<Consultation>> GetAllByPatientIdAsync(Guid patientId)
    {
        return Task.FromResult(_consultations.Where(c => c.PatientId == patientId));
    }
}
