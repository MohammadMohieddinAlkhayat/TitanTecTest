using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class CustomsDeclaration
    {
        [Key]
        public string DeclarationId { get; set; }

        [ForeignKey("ConsolidatedPackage")]
        public string PackageId { get; set; }

        [Required]
        public string ContentDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeclaredValue { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        public string[] RequiredDocuments { get; set; }

        public bool ContainsPharmacy { get; set; }

        public bool ContainsFood { get; set; }

        [Required]
        public string SenderInfo { get; set; }

        [Required]
        public string RecipientInfo { get; set; }

        public virtual ConsolidatedPackage Package { get; set; }

        public CustomsDeclaration()
        {
            DeclarationId = Guid.NewGuid().ToString();
        }

        public virtual void ValidateDocuments() { }
        public virtual decimal CalculateDuties() { return 0; }
        public virtual void SubmitDeclaration() { }
    }
}
