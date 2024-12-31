using StoreMVC.Models.Domain;
using StoreMVC.Services.Products;

namespace StoreMVC.Factories
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductService _productService;

        public ProductFactory(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IList<Product>> PrepareAllProductListAsync()
        {
            var products = await _productService.GetAllProductAsync();
            var productList = new List<Product>();
            foreach (var product in products)
            {
                product.ImageFileName = Path.Combine("/productimages/", product.ImageFileName);
                productList.Add(product);
            }
            return productList;
        }
    }
}
