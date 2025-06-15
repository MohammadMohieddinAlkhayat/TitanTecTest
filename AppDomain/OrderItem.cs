using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class OrderItem
    {
        [Key]
        public string OrderItemId { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPriceInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPriceInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        public string Customizations { get; set; }

        public string Notes { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderItem()
        {
            OrderItemId = Guid.NewGuid().ToString();
        }

        public virtual void CalculateSubtotal() { }
        public virtual void UpdateQuantity() { }
        public virtual void ConvertPriceToCurrency() { }
    }
}
