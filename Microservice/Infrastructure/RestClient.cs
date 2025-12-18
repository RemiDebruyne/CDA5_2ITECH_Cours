using System.Text;
using System.Text.Json;

namespace Infrastructure;

public class RestClient<TGet>(string baseUrl)
{
    private readonly string _BaseUrl = baseUrl;
    private readonly HttpClient _client = new HttpClient();
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public async Task<TGet> GetRequest(string url)
    {
        var response = await _client.GetAsync(_BaseUrl + url);
        if (!response.IsSuccessStatusCode) throw new Exception("Error while fetching ressource");
        
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TGet>(json, _serializerOptions);
        return result ?? throw new Exception("Result Null");
    }
    
    
    public async Task<List<TGet>> GetListRequest(string url)
    {
        var response = await _client.GetAsync(_BaseUrl + url);
        if (!response.IsSuccessStatusCode) throw new Exception("Error while fetching ressource");
        
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<TGet>>(json, _serializerOptions);
        return result ?? throw new Exception("Result Null");
    }
    
    

}