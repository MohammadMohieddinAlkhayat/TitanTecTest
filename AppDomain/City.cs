using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class City
    {
        [Key]
        public string CityId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        public bool IsServiceAvailable { get; set; }

        public string[] SupportedServices { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFee { get; set; }

        [MaxLength(3)]
        public string DeliveryFeeCurrency { get; set; }

        public int EstimatedDeliveryTime { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }

        public City()
        {
            CityId = Guid.NewGuid().ToString();
            Vendors = new HashSet<Vendor>();
            Addresses = new HashSet<Address>();
            Receivers = new HashSet<Receiver>();
            Drivers = new HashSet<Driver>();
        }

        public virtual void UpdateServiceAvailability() { }
        public virtual double CalculateDistance(City otherCity) { return 0; }
        public virtual void ConvertDeliveryFee() { }
    }
}
