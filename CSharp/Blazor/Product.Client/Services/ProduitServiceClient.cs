using System.Net.Http.Json;
using Product.Domain.Models;

namespace Product.Client.Services;


public class ProduitServiceClient(HttpClient http) : IProduitServiceClient
{
    private const string BaseUrl = "http://localhost:5117/api/Produits";

    public async Task<List<Produit>> ObtenirTousAsync()
    {
        try
        {
            Console.WriteLine(http.BaseAddress);
            List<Produit> result = await http.GetFromJsonAsync<List<Produit>>(BaseUrl);
            Console.WriteLine(result);
            return result ?? [];
        }
        catch
        {
            throw;
        }
    }

    public async Task<Produit?> ObtenirParIdAsync(int id)
    {
        try
        {
            var result = await http.GetFromJsonAsync<Produit?>($"{BaseUrl}/{id}");
            return result ?? null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<Produit>> RechercherAsync(string terme)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Produit>> ObtenirParCategorieAsync(string categorie)
    {
        try
        {
            return await http.GetFromJsonAsync<List<Produit>>($"{BaseUrl}/categorie/{categorie}");
            
        }
        catch
        {
            return [];
        }
    }

    public async Task<Produit?> AjouterAsync(ProduitDto dto)
    {
        try
        {
            HttpResponseMessage response = await http.PostAsync($"{BaseUrl}", JsonContent.Create(dto));

            return await response.Content.ReadFromJsonAsync<Produit>() ?? null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Produit?> ModifierAsync(int id, ProduitDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SupprimerAsync(int id)
    {
        try
        {
            HttpResponseMessage response = await http.DeleteAsync($"{BaseUrl}/{id}");

            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<string>> ObtenirCategoriesAsync()
    {
        throw new NotImplementedException();
    }
}
