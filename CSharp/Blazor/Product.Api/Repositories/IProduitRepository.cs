using Product.Domain.Models;

namespace Product.Api.Repositories
{
    public interface IProduitRepository : IRepository<Produit>
    {

        Task<IEnumerable<Produit>> RechercherAsync(string terme);
        Task<IEnumerable<Produit>> GetByCategorieAsync(string categorie);
        Task<IEnumerable<string>> GetCategoriesAsync();
        Task<decimal> GetValeurStockAsync();

    }
}
