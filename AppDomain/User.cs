using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(3)]
        public string PreferredCurrency { get; set; }

        public bool IsVerified { get; set; }

        public DateTime RegistrationDate { get; set; }

        [MaxLength(10)]
        public string PreferredLanguage { get; set; }

        public string ProfileImage { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public User()
        {
            UserId = Guid.NewGuid().ToString();
            RegistrationDate = DateTime.UtcNow;
            Notifications = new HashSet<Notification>();
        }

        public virtual void Register() { }
        public virtual void Login() { }
        public virtual void VerifyAccount() { }
        public virtual void UpdateProfile() { }
        public virtual void ResetPassword() { }
        public virtual void ChangeRole() { }
        public virtual void UpdateCurrencyPreference() { }
    }
}
