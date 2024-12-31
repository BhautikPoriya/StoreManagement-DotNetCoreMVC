using StoreMVC.Models.Domain;

namespace StoreMVC.Factories
{
    public interface IProductFactory
    {

        Task<IList<Product>> PrepareAllProductListAsync();

    }
}
