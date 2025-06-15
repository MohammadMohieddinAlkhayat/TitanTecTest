using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Notification
    {
        [Key]
        public string NotificationId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public NotificationType Type { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentDate { get; set; }

        public bool IsRead { get; set; }

        public string[] Channels { get; set; }

        public string RelatedEntityId { get; set; }

        public virtual User User { get; set; }

        public Notification()
        {
            NotificationId = Guid.NewGuid().ToString();
            SentDate = DateTime.UtcNow;
        }

        public virtual void SendNotification() { }
        public virtual void MarkAsRead() { IsRead = true; }
        public virtual void ScheduleNotification() { }
    }
}
