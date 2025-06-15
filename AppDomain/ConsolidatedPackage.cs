using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class ConsolidatedPackage
    {
        [Key]
        public string PackageId { get; set; }

        public string[] OrderIds { get; set; }

        public string[] PackageRequestIds { get; set; }

        [MaxLength(50)]
        public string OriginCountry { get; set; }

        [MaxLength(50)]
        public string DestinationCountry { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalWeight { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalValue { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime ConsolidationDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string TrackingNumber { get; set; }

        [ForeignKey("CustomsDeclaration")]
        public string CustomsInfoId { get; set; }

        public virtual CustomsDeclaration CustomsInfo { get; set; }

        public ConsolidatedPackage()
        {
            PackageId = Guid.NewGuid().ToString();
            ConsolidationDate = DateTime.UtcNow;
        }

        public virtual void AddOrder() { }
        public virtual void AddPackageRequest() { }
        public virtual void CalculateShipping() { }
        public virtual void GenerateCustomsForm() { }
        public virtual void OptimizePackaging() { }
    }
}
