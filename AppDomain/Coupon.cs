using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Coupon
    {
        [Key]
        public string CouponId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public CouponType Type { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValueInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MinimumOrderValue { get; set; }

        [MaxLength(3)]
        public string MinimumOrderCurrency { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int MaxUses { get; set; }

        public int CurrentUses { get; set; }

        public int MaxUsesPerCustomer { get; set; }

        public string[] ApplicableCategories { get; set; }

        public string[] ApplicableVendors { get; set; }

        public string[] ApplicableCities { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public virtual ICollection<CouponUsage> CouponUsages { get; set; }

        public Coupon()
        {
            CouponId = Guid.NewGuid().ToString();
            CouponUsages = new HashSet<CouponUsage>();
        }

        public virtual bool ValidateCoupon() { return IsActive && DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate; }
        public virtual decimal ApplyDiscount(decimal orderValue) { return 0; }
        public virtual void TrackUsage() { }
        public virtual bool CheckEligibility(string customerId) { return true; }
        public virtual void Deactivate() { IsActive = false; }
        public virtual decimal ConvertDiscountToCurrency(string targetCurrency) { return DiscountValue; }
    }
}
