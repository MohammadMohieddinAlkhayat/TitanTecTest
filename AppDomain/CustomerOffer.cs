using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class CustomerOffer
    {
        [Key]
        public string CustomerOfferId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("Offer")]
        public string OfferId { get; set; }

        public DateTime AssignedDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsUsed { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }

        public DateTime? UsedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual Order Order { get; set; }

        public CustomerOffer()
        {
            CustomerOfferId = Guid.NewGuid().ToString();
            AssignedDate = DateTime.UtcNow;
        }

        public virtual void AssignToCustomer() { }
        public virtual void MarkAsUsed() { IsUsed = true; UsedDate = DateTime.UtcNow; }
        public virtual bool CheckExpiry() { return DateTime.UtcNow > ExpiryDate; }
    }
}
