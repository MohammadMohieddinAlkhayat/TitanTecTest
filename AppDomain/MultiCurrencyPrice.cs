using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class MultiCurrencyPrice
    {
        [Key]
        public string PriceId { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }

        [ForeignKey("Currency")]
        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime EffectiveDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }

        public MultiCurrencyPrice()
        {
            PriceId = Guid.NewGuid().ToString();
        }

        public virtual void UpdatePrice() { }
        public virtual decimal ConvertToCurrency(string targetCurrency) { return Price; }
    }
}
