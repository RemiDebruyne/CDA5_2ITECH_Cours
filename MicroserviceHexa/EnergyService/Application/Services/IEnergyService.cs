using EnergyApi.Application.Dto;
using EnergyApi.Domain.Entities;

namespace EnergyApi.Application.Services;

public interface IEnergyService
{
    public Task<List<EnergyResponseDto>> GetAllAsync();

    public Task<EnergyResponseDto> GetEnergyByIdAsync(int id);

    public Task<EnergyResponseDto> AddEnergyAsync(CreateEnergyDto createEnergyDto);
}
