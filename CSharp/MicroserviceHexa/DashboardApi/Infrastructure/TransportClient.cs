using DashboardApi.Application.Dto;
using DashboardApi.Domain.Port;

namespace DashboardApi.Infrastructure;

public class TransportClient : RestClient, ITransportClient
{
    protected override string BaseUrl { get; set; } = "http://localhost:5233/api";
}
