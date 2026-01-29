using Product.Domain.Models;

namespace Product.Api.Services
{
    public interface IProduitService
    {
        Task<List<Produit>> ObtenirTousAsync();
        Task<Produit?> ObtenirParIdAsync(int id);
        Task<List<Produit>> RechercherAsync(string terme);
        Task<List<Produit>> ObtenirParCategorieAsync(string categorie);
        Task<Produit> AjouterAsync(ProduitDto dto);
        Task<Produit?> ModifierAsync(int id, ProduitDto dto);
        Task<bool> SupprimerAsync(int id);
        Task<List<string>> ObtenirCategoriesAsync();

    }
}
