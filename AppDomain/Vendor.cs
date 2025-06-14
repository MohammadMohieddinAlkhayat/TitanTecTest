using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Vendor : User
    {
        [Key]
        public string VendorId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string BusinessName { get; set; }

        public string BusinessLicense { get; set; }

        public VendorType VendorType { get; set; }

        [ForeignKey("City")]
        public string CityId { get; set; }

        public string ContactInfo { get; set; }

        public string BusinessHours { get; set; }

        public bool IsActive { get; set; }

        public bool IsVerified { get; set; }

        [Range(0,5)]
        public double Rating { get; set; }

        public string BankAccountInfo { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public Vendor()
        {
            VendorId = Guid.NewGuid().ToString();
            Products = new HashSet<Product>();
            Offers = new HashSet<Offer>();
        }

        public virtual void AddProduct() { }
        public virtual void UpdateInventory() { }
        public virtual void ProcessOrder() { }
        public virtual void UpdateBusinessInfo() { }
        public virtual void ViewSalesReport() { }
    }
}
