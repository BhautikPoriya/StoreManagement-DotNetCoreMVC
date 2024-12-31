using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMVC.Models.Domain
{
    /// <summary>
    /// Represents a product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        [MaxLength(100)]
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product description
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product category
        /// </summary>
        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product manufacturer
        /// </summary>
        [MaxLength(100)] 
        public string Manufacturer {  get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product price
        /// </summary>
        [Precision(16,2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product image file name
        /// </summary>
        [MaxLength(100)]
        public string ImageFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time for product creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
