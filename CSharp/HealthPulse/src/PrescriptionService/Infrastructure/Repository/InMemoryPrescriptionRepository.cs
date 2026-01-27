using Microsoft.AspNetCore.Identity;
using PrescriptionService.Domain.Entities;
using PrescriptionService.Domain.Ports;

namespace PrescriptionService.Infrastructure.Repository;

public class InMemoryPrescriptionRepository : IPrescriptionRepository
{
    private List<Prescription> _prescription = [];

    public Task<Prescription> CreateAsync(Prescription prescription)
    {
        prescription.Id = Guid.NewGuid();

        _prescription.Add(prescription);

        return Task.FromResult(prescription);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var prescription = _prescription.FirstOrDefault(p => p.Id == id);

        _prescription.Remove(prescription);

        return Task.FromResult(true);
    }

    public Task<IEnumerable<Prescription>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Prescription>>(_prescription);
    }

    public Task<IEnumerable<Prescription>> GetByConsultationIdAsync(Guid consultationId)
    {
        return Task.FromResult(_prescription.Where(p => p.ConsultationId == consultationId)); 
    }

    public Task<Prescription?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Prescription?> UpdateAsync(Guid id, Prescription prescription)
    {
        throw new NotImplementedException();
    }
}
