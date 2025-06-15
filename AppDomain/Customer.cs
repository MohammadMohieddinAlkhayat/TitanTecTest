using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Customer : User
    {
        [Key]
        public string CustomerId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public string LoyaltyPoints { get; set; }

        public virtual ICollection<PaymentMethod> SavedPaymentMethods { get; set; }
        public virtual ICollection<Order> OrderHistory { get; set; }
        public virtual ICollection<Receiver> SavedReceivers { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<PackageRequest> PackageRequests { get; set; }
        public virtual ICollection<CouponUsage> CouponUsages { get; set; }
        public virtual ICollection<CustomerOffer> CustomerOffers { get; set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid().ToString();
            SavedPaymentMethods = new HashSet<PaymentMethod>();
            OrderHistory = new HashSet<Order>();
            SavedReceivers = new HashSet<Receiver>();
            Reviews = new HashSet<Review>();
            PackageRequests = new HashSet<PackageRequest>();
            CouponUsages = new HashSet<CouponUsage>();
            CustomerOffers = new HashSet<CustomerOffer>();
        }

        public virtual void CreateOrder() { }
        public virtual void AddReceiver() { }
        public virtual void TrackOrder() { }
        public virtual void ReorderPrevious() { }
        public virtual void EarnLoyaltyPoints() { }
    }
}
