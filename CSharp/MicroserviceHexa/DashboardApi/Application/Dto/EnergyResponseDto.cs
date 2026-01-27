
namespace DashboardApi.Application.Dto;

public class EnergyResponseDto
{
    public int Id { get; set; }

    public string Source { get; set; }

    public int EnergyConsumption { get; set; }

    public DateTime Date { get; set; }
}
