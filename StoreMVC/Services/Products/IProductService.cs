using StoreMVC.Models.Domain;

namespace StoreMVC.Services.Products
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>result</returns>

        Task<IList<Product>> GetAllProductAsync();

        /// <summary>
        /// Insert a product
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task ProductInsertAsync(Product product);
    }
}
