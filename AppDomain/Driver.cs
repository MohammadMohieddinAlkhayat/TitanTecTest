using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Driver : User
    {
        [Key]
        public string DriverId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string VehicleType { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [ForeignKey("City")]
        public string CityId { get; set; }

        [Range(0,5)]
        public double Rating { get; set; }

        public bool IsAvailable { get; set; }

        public string CurrentLocation { get; set; }

        public string[] WorkingAreas { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Shipment> ActiveShipments { get; set; }

        public Driver()
        {
            DriverId = Guid.NewGuid().ToString();
            ActiveShipments = new HashSet<Shipment>();
        }

        public virtual void UpdateLocation() { }
        public virtual void AcceptDelivery() { }
        public virtual void CompleteDelivery() { }
        public virtual void UpdateAvailability() { }
        public virtual void ViewEarnings() { }
    }
}
