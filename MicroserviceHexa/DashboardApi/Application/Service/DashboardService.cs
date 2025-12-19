
using DashboardApi.Application.Dto;
using DashboardApi.Domain.Port;

namespace DashboardApi.Application.Service;

public class DashboardService(
    IEnergyClient energyClient,
    ITransportClient transportClient,
    IWasteClient wasteClient) : IDashboardService
{
    public async Task<int> GetTotalCo2Emission()
    {
        List<TransportResponseDto> transports = await transportClient.GetAsync<List<TransportResponseDto>>("/transports");

        int totalCo2Emission = 0;

        foreach(TransportResponseDto transport in transports)
        {
            totalCo2Emission += await transportClient.GetAsync<int>($"/transports/{transport.Id}/emission");
        }

        return totalCo2Emission;
    }

    public async Task<int> GetTotalEnergyConsumption()
    {
        List<EnergyResponseDto> energyResponseDtos = await energyClient.GetAsync<List<EnergyResponseDto>>("/energies");

        return energyResponseDtos.Select(e => e.EnergyConsumption).Sum();
    }

    public async Task<int> GetTotalWasteQuantity()
    {
        List<WasteResponseDto> wasteResponseDtos = await wasteClient.GetAsync<List<WasteResponseDto>>("/wastes");


        return wasteResponseDtos.Select(e => e.Quantity).Sum();
    }

    public async Task<DashboardResponseDto> GetDashboard()
    {
        return new DashboardResponseDto()
        {
            TotalCo2Emission = await GetTotalCo2Emission(),
            TotalEnergyConsumption = await GetTotalEnergyConsumption(),
            TotalWaste = await GetTotalWasteQuantity()
        };
    }
}
