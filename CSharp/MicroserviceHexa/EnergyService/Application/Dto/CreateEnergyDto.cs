using EnergyService.Domain.Entities;

namespace EnergyApi.Application.Dto;

public class CreateEnergyDto
{
    public EnergySource Source { get; set; }

    public int EnergyConsumption { get; set; }

    public DateTime Date { get; set; }
}
