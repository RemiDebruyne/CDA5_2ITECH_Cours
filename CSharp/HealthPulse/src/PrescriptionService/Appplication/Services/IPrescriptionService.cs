using PrescriptionService.Appplication.Dtos;

namespace PrescriptionService.Appplication.Services;

public interface IPrescriptionService
{
    Task<IEnumerable<PrescriptionResponseDto>> GetAllAsync();

    Task<PrescriptionResponseDto?> GetByIdAsync(Guid id);

    Task<PrescriptionResponseDto> CreateAsync(PrescriptionRequestDto dto);

    Task<PrescriptionResponseDto?> UpdateAsync(Guid id, PrescriptionRequestDto dto);

    Task<bool> DeleteAsync(Guid id);

    Task<TotalPrisesResponseDto> GetTotalPrisesResponseDto(Guid id);
}
