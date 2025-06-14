using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlatform.Models
{
    public class ExchangeRate
    {
        [Key]
        public string RateId { get; set; }

        [ForeignKey("FromCurrency")]
        [MaxLength(3)]
        public string FromCurrency { get; set; }

        [ForeignKey("ToCurrency")]
        [MaxLength(3)]
        public string ToCurrency { get; set; }

        [Column(TypeName = "decimal(10,6)")]
        public decimal Rate { get; set; }

        public DateTime EffectiveDate { get; set; }

        [MaxLength(50)]
        public string Source { get; set; }

        public bool IsActive { get; set; }

        public virtual Currency FromCurrencyNavigation { get; set; }
        public virtual Currency ToCurrencyNavigation { get; set; }
        public virtual ICollection<CurrencyConversion> CurrencyConversions { get; set; }

        public ExchangeRate()
        {
            RateId = Guid.NewGuid().ToString();
            CurrencyConversions = new HashSet<CurrencyConversion>();
        }

        public virtual void UpdateRate() { }
        public virtual decimal ConvertAmount(decimal amount) { return amount * Rate; }
        public virtual decimal GetHistoricalRate(DateTime date) { return Rate; }
    }
}
