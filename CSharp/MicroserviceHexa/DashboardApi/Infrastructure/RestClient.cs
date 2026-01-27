using DashboardApi.Domain.Port;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DashboardApi.Infrastructure;

public abstract class RestClient : IRestClient
{

protected abstract string BaseUrl { get; set; }

    private readonly JsonSerializerOptions _options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
    };

    private readonly HttpClient _client;

    public RestClient()
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl)
        };
    }


    public async Task<T> GetAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Response from {BaseUrl}{url} return {response.StatusCode}");
        }

        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _options);
    }

}
