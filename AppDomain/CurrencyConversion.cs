using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class CurrencyConversion
    {
        [Key]
        public string ConversionId { get; set; }

        [MaxLength(3)]
        public string FromCurrency { get; set; }

        [MaxLength(3)]
        public string ToCurrency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ConvertedAmount { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        public DateTime ConversionDate { get; set; }

        public string ReferenceId { get; set; }

        public virtual ExchangeRate ExchangeRateNavigation { get; set; }

        public CurrencyConversion()
        {
            ConversionId = Guid.NewGuid().ToString();
            ConversionDate = DateTime.UtcNow;
        }

        public virtual void PerformConversion() { }
        public virtual void LogConversion() { }
    }
}
