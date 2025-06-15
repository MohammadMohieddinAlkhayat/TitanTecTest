using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Review
    {
        [Key]
        public string ReviewId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; }

        public bool IsVerified { get; set; }

        public string[] Images { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

        public Review()
        {
            ReviewId = Guid.NewGuid().ToString();
            ReviewDate = DateTime.UtcNow;
        }

        public virtual void SubmitReview() { }
        public virtual void UpdateReview() { }
        public virtual void FlagInappropriate() { }
    }
}
