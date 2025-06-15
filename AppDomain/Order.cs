using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [MaxLength(3)]
        public string DisplayCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmountInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        [ForeignKey("Payment")]
        public string PaymentId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EstimatedDelivery { get; set; }

        [ForeignKey("Shipment")]
        public string ShipmentId { get; set; }

        public string SpecialInstructions { get; set; }

        public string CouponCode { get; set; }

        [ForeignKey("Offer")]
        public string OfferId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; }

        [MaxLength(3)]
        public string DiscountCurrency { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Receiver Receiver { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
            Items = new HashSet<OrderItem>();
        }

        public virtual void CalculateTotal() { }
        public virtual void ApplyCoupon() { }
        public virtual void ApplyOffer() { }
        public virtual void UpdateStatus() { }
        public virtual void GenerateInvoice() { }
        public virtual void RequestRefund() { }
        public virtual void ConvertCurrency() { }
        public virtual void RecalculateWithExchangeRate() { }
    }
}
