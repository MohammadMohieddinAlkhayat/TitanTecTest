using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [MaxLength(3)]
        public string BaseCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountInBaseCurrency { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        public string TransactionReference { get; set; }

        public string GatewayResponse { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProcessingFee { get; set; }

        [MaxLength(3)]
        public string ProcessingFeeCurrency { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Payment()
        {
            PaymentId = Guid.NewGuid().ToString();
            PaymentDate = DateTime.UtcNow;
        }

        public virtual void ProcessPayment() { }
        public virtual void RefundPayment() { }
        public virtual void VerifyTransaction() { }
        public virtual void SendReceipt() { }
        public virtual void ConvertToBaseCurrency() { }
        public virtual void HandleMultiCurrencyTransaction() { }
    }
}
