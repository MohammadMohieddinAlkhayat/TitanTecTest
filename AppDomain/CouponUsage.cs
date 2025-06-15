using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class CouponUsage
    {
        [Key]
        public string UsageId { get; set; }

        [ForeignKey("Coupon")]
        public string CouponId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }

        public DateTime UsedDate { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountApplied { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAppliedInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }

        public CouponUsage()
        {
            UsageId = Guid.NewGuid().ToString();
            UsedDate = DateTime.UtcNow;
        }

        public virtual void RecordUsage() { }
        public virtual bool ValidateUsage() { return true; }
        public virtual void ConvertDiscountToCurrency() { }
    }
}
