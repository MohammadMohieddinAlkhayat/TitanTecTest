using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class Currency
    {
        [Key]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string CurrencyName { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; }

        public int DecimalPlaces { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal ExchangeRate { get; set; }

        public DateTime LastUpdated { get; set; }

        public virtual ICollection<ExchangeRate> FromExchangeRates { get; set; }
        public virtual ICollection<ExchangeRate> ToExchangeRates { get; set; }
        public virtual ICollection<MultiCurrencyPrice> Prices { get; set; }

        public Currency()
        {
            FromExchangeRates = new HashSet<ExchangeRate>();
            ToExchangeRates = new HashSet<ExchangeRate>();
            Prices = new HashSet<MultiCurrencyPrice>();
        }

        public virtual void UpdateExchangeRate() { }
        public virtual string FormatAmount(decimal amount) { return $"{Symbol}{amount:F2}"; }
        public virtual bool IsSupported() { return IsActive; }
    }
}
