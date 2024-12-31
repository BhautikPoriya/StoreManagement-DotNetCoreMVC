using Microsoft.AspNetCore.Mvc;
using StoreMVC.Factories;
using StoreMVC.Models;
using StoreMVC.Models.Domain;
using StoreMVC.Services.Products;

namespace StoreMVC.Controllers
{
    public class ProductController : Controller
    {

        #region Fields

        private readonly IProductService _productService;
        private readonly IProductFactory _productFactory;

        #endregion

        #region Ctor

        public ProductController(IProductService productService,
            IProductFactory productFactory)
        {
            _productService = productService;   
            _productFactory = productFactory;
        }

        #endregion

        #region Methods 

        public async Task<IActionResult> Index()
        {
            var model = await _productFactory.PrepareAllProductListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            if (productModel.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image is requied");
            }

            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Create));

            var dateTimeString = DateTime.Now.ToString("yyyyMMddHHmmss");

            var fileName = dateTimeString + "_" + Path.GetFileName(productModel.ImageFile.FileName);
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "productimages");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await productModel.ImageFile.CopyToAsync(stream);
            }

            // insert a product
            var product = new Product()
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Category = productModel.Category,
                Manufacturer = productModel.Manufacturer,
                Price = productModel.Price,
                ImageFileName = fileName,
                CreatedOnUtc = DateTime.Now,
            };
            await _productService.ProductInsertAsync(product);

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
