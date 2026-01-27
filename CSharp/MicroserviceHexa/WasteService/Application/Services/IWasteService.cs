using WasteApi.Application.Dto;

namespace WasteApi.Application.Services;

public interface IWasteService
{
    Task<List<WasteResponseDto>> GetAllAsync();

    Task<WasteResponseDto> GetByIdAsync(int id);

    Task<WasteResponseDto> AddAsync(CreateWasteDto createWasteDto);

    Task UpdateAsync(UpdateWasteDto updateWasteDto);
}
