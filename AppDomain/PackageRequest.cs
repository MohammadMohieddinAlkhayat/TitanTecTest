using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class PackageRequest
    {
        [Key]
        public string PackageRequestId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string PackageDescription { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Weight { get; set; }

        public string Dimensions { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime EstimatedShipDate { get; set; }

        public DateTime? ActualShipDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }

        public string TrackingNumber { get; set; }

        public string SpecialHandling { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Receiver Receiver { get; set; }

        public PackageRequest()
        {
            PackageRequestId = Guid.NewGuid().ToString();
        }

        public virtual void CreatePackageRequest() { }
        public virtual void UpdateStatus() { }
        public virtual void CalculateShippingCost() { }
        public virtual void SchedulePickup() { }
    }
}
