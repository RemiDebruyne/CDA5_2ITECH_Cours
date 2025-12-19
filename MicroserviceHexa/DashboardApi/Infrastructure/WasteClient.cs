using DashboardApi.Application.Dto;
using DashboardApi.Domain.Port;

namespace DashboardApi.Infrastructure;

public class WasteClient : RestClient, IWasteClient
{
    protected override string BaseUrl { get; set; } = "http://localhost:5142";
}
