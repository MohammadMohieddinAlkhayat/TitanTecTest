using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Shipment
    {
        [Key]
        public string ShipmentId { get; set; }

        public ShipmentType ShipmentType { get; set; }

        public ShipmentStatus Status { get; set; }

        public DateTime EstimatedDelivery { get; set; }

        public DateTime? ActualDelivery { get; set; }

        public string TrackingNumber { get; set; }

        [ForeignKey("Driver")]
        public string DriverId { get; set; }

        [ForeignKey("OriginCity")]
        public string OriginCityId { get; set; }

        [ForeignKey("DestinationCity")]
        public string DestinationCityId { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCostInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        public string[] StatusUpdates { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual City OriginCity { get; set; }
        public virtual City DestinationCity { get; set; }

        public Shipment()
        {
            ShipmentId = Guid.NewGuid().ToString();
        }

        public virtual void AssignDriver() { }
        public virtual void UpdateStatus() { }
        public virtual void CalculateShippingCost() { }
        public virtual void GenerateTrackingInfo() { }
        public virtual void ConvertShippingCost() { }
    }
}
