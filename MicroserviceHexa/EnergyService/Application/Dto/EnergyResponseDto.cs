using EnergyApi.Domain.Entities;
using System.Diagnostics;

namespace EnergyApi.Application.Dto;

public class EnergyResponseDto
{
    public int Id { get; set; }

    public string Source { get; set; }

    public int EnergyConsumption { get; set; }

    public DateTime Date { get; set; }

    public static EnergyResponseDto FromEnergy(Energy energy)
    {
        return new EnergyResponseDto
        {
            Id = energy.Id,
            Source = energy.Source.ToString(),
            EnergyConsumption = energy.EnergyConsumption,
            Date = energy.Date,
        };
    }
}
