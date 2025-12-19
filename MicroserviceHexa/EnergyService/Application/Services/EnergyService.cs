

using EnergyApi.Application.Dto;
using EnergyApi.Domain.Entities;
using EnergyApi.Domain.Ports;

namespace EnergyApi.Application.Services;

public class EnergyService(IEnergyRepository repository) : IEnergyService
{
    public async Task<EnergyResponseDto> AddEnergyAsync(CreateEnergyDto createEnergyDto)
    {
        var energy = await repository.AddAsync(new Energy()
        {
            Source = createEnergyDto.Source,
            EnergyConsumption = createEnergyDto.EnergyConsumption,
            Date = createEnergyDto.Date,
        });

        return EnergyResponseDto.FromEnergy(energy);
    }

    public async Task<List<EnergyResponseDto>> GetAllAsync()
    {
        var energies = await repository.GetAllAsync();

        return [.. energies.Select(e => EnergyResponseDto.FromEnergy(e))];
    }

    public async Task<EnergyResponseDto> GetEnergyByIdAsync(int id)
    {
        var energy = await repository.GetByIdAsync(id);

        if(energy is null)
        {
            return null;
        }

        return EnergyResponseDto.FromEnergy(energy);
    }
}
