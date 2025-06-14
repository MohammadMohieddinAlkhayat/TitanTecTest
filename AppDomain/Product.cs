using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        [ForeignKey("Vendor")]
        public string VendorId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ProductCategory Category { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }

        public string[] Images { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Weight { get; set; }

        public string Dimensions { get; set; }

        public string Restrictions { get; set; }

        public string[] Tags { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<MultiCurrencyPrice> Prices { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid().ToString();
            Prices = new HashSet<MultiCurrencyPrice>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
        }

        public virtual void UpdateStock() { }
        public virtual bool CheckAvailability() { return IsAvailable && StockQuantity > 0; }
        public virtual void ApplyDiscount() { }
        public virtual ICollection<Review> GetReviews() { return Reviews; }
        public virtual decimal GetPriceInCurrency(string currency) { return BasePrice; }
        public virtual void UpdateMultiCurrencyPrices() { }
    }
}
