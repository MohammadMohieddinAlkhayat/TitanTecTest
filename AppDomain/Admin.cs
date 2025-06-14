using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Admin : User
    {
        [Key]
        public string AdminId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public AdminLevel AccessLevel { get; set; }

        public string[] Permissions { get; set; }

        public DateTime LastLogin { get; set; }

        public Admin()
        {
            AdminId = Guid.NewGuid().ToString();
        }

        public virtual void ApproveVendor() { }
        public virtual void ManageUsers() { }
        public virtual void ViewSystemReports() { }
        public virtual void HandleDisputes() { }
        public virtual void ConfigureSystem() { }
    }
}
