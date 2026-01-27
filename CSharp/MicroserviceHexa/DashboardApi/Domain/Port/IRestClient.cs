namespace DashboardApi.Domain.Port;

public interface IRestClient
{
    Task<T> GetAsync<T>(string url);

}
