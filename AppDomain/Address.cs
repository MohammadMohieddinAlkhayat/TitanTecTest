using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Address
    {
        [Key]
        public string AddressId { get; set; }

        [Required]
        public string Street { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }

        [ForeignKey("City")]
        public string CityId { get; set; }

        public string Landmark { get; set; }

        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        public bool IsVerified { get; set; }

        public string DeliveryInstructions { get; set; }

        public virtual City City { get; set; }

        public Address()
        {
            AddressId = Guid.NewGuid().ToString();
        }

        public virtual void ValidateAddress() { }
        public virtual void GetCoordinates() { }
        public virtual void VerifyLocation() { }
    }
}
