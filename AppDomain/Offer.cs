using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Offer
    {
        [Key]
        public string OfferId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public OfferType Type { get; set; }

        public string[] TargetProductIds { get; set; }

        public string[] TargetCategories { get; set; }

        [ForeignKey("Vendor")]
        public string VendorId { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmountInBaseCurrency { get; set; }

        public int MinimumQuantity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public string[] ApplicableCities { get; set; }

        public int Priority { get; set; }

        public string BannerImage { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<CustomerOffer> CustomerOffers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Offer()
        {
            OfferId = Guid.NewGuid().ToString();
            CustomerOffers = new HashSet<CustomerOffer>();
            Orders = new HashSet<Order>();
        }

        public virtual void CreateOffer() { }
        public virtual void UpdateOffer() { }
        public virtual bool CheckApplicability(string productId) { return true; }
        public virtual decimal CalculateDiscount(decimal originalPrice) { return 0; }
        public virtual void ActivateOffer() { IsActive = true; }
        public virtual void DeactivateOffer() { IsActive = false; }
        public virtual decimal ConvertDiscountToCurrency(string targetCurrency) { return DiscountAmount; }
    }
}
