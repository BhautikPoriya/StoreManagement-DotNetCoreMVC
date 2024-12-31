using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "The name is required"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The category is required"), MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "The manufacturer is required"), MaxLength(100)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = "The price is required")]
        public decimal Price { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
