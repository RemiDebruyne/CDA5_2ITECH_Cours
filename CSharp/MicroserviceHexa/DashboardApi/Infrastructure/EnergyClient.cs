using DashboardApi.Application.Dto;
using DashboardApi.Domain.Port;

namespace DashboardApi.Infrastructure;

public class EnergyClient : RestClient, IEnergyClient
{
    protected override string BaseUrl { get; set; } = "http://localhost:5055/api";

}
