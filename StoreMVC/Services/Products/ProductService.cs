using Microsoft.EntityFrameworkCore;
using StoreMVC.Models.Domain;
using StoreMVC.Services.DatabaseContext;

namespace StoreMVC.Services.Products
{
    /// <summary>
    /// Product service
    /// </summary>
    public class ProductService : IProductService
    {
        #region Fields

        private readonly StoreDbContext _storeDbContext;

        #endregion

        #region Ctor

        public ProductService(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;   
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>result</returns>
        public async Task<IList<Product>> GetAllProductAsync()
        {
            return await _storeDbContext.Product.ToListAsync();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Insert a product
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task ProductInsertAsync(Product product)
        {
            await _storeDbContext.Product.AddAsync(product);
            await _storeDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
