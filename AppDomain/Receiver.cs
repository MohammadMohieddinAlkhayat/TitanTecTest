using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Receiver
    {
        [Key]
        public string ReceiverId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Phone]
        public string AlternatePhone { get; set; }

        [MaxLength(50)]
        public string Relationship { get; set; }

        [ForeignKey("Address")]
        public string AddressId { get; set; }

        [ForeignKey("City")]
        public string CityId { get; set; }

        public bool IsVerified { get; set; }

        public string SpecialInstructions { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PackageRequest> PackageRequests { get; set; }

        public Receiver()
        {
            ReceiverId = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
            PackageRequests = new HashSet<PackageRequest>();
        }

        public virtual void UpdateContactInfo() { }
        public virtual void VerifyIdentity() { }
        public virtual void ConfirmDelivery() { }
    }
}
