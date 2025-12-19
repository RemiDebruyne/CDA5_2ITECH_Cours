using WasteApi.Application.Dto;
using WasteApi.Domain.Entities;
using WasteApi.Domain.Ports;

namespace WasteApi.Application.Services;

public class WasteService(IWasteRepository repository) : IWasteService
{
    public async Task<WasteResponseDto> AddAsync(CreateWasteDto createWasteDto)
    {
        var waste = await repository.AddAsync(new Waste()
        {
            Quantity = createWasteDto.Quantity,
            RecyclingRate = createWasteDto.RecyclingRate,
            WasteType = createWasteDto.WasteType,
        });

        return WasteResponseDto.FromWaste(waste);
    }

    public async Task<List<WasteResponseDto>> GetAllAsync()
    {
        var wastes = await repository.GetAllAsync();

        return [.. wastes.Select(waste => WasteResponseDto.FromWaste(waste))];
    }

    public async Task<WasteResponseDto> GetByIdAsync(int id)
    {
        var waste = await repository.GetByIdAsync(id);

        if (waste is null)
        {
            return null;
        }

        return WasteResponseDto.FromWaste(waste);
    }

    public async Task UpdateAsync(UpdateWasteDto updateWasteDto)
    {
        await repository.Update(updateWasteDto.Id, new Waste()
        {
            Id = updateWasteDto.Id,
            Quantity = updateWasteDto.Quantity,
            RecyclingRate = updateWasteDto.RecyclingRate,
            WasteType = updateWasteDto.WasteType,
        });
    }
}
