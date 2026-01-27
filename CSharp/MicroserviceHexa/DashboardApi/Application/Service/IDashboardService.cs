using DashboardApi.Application.Dto;

namespace DashboardApi.Application.Service;

public interface IDashboardService
{
    Task<int> GetTotalEnergyConsumption();

    Task<int> GetTotalWasteQuantity();

    Task<int> GetTotalCo2Emission();

    Task<DashboardResponseDto> GetDashboard();
}
