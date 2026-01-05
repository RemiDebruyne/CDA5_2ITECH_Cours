using PrescriptionService.Appplication.Dtos;
using PrescriptionService.Appplication.Mappers;
using PrescriptionService.Domain.Entities;
using PrescriptionService.Domain.Ports;
using System.Diagnostics.CodeAnalysis;

namespace PrescriptionService.Appplication.Services;

public class PrescriptionAppService(IPrescriptionRepository repository) : IPrescriptionService
{
    public async Task<PrescriptionResponseDto> CreateAsync(PrescriptionRequestDto dto)
    {
        var prescription = await repository.CreateAsync(PrescriptionMapper.ToEntity(dto));
        return PrescriptionMapper.ToDto(prescription);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PrescriptionResponseDto>> GetAllAsync()
    {
        var prescriptions = await repository.GetAllAsync();

        return PrescriptionMapper.ToDtoList(prescriptions);
    }

    public async Task<PrescriptionResponseDto?> GetByIdAsync(Guid id)
    {
        var prescription = await repository.GetByIdAsync(id);

        if (prescription is null) return null;

        return PrescriptionMapper.ToDto(prescription);
    }

    public async Task<TotalPrisesResponseDto> GetTotalPrisesResponseDto(Guid id)
    {
        var prescription = await repository.GetByIdAsync(id);

        if (prescription is null) return null;

        return PrescriptionMapper.TotalPrisesResponseDto(prescription);
    }

    public async Task<PrescriptionResponseDto?> UpdateAsync(Guid id, PrescriptionRequestDto dto)
    {
        var prescription = PrescriptionMapper.ToEntity(dto);

        Prescription? updated = await repository.UpdateAsync(id, prescription);

        return updated != null ? PrescriptionMapper.ToDto(updated) : null;
    }
}
