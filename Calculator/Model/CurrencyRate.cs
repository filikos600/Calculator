using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data
{

    public class CurrencyRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string currencyCode { get; set; }

        [Required]
        public double exchangeRate { get; set; }

        [Required]
        public int CurrencyRateDateId { get; set; }
        public CurrencyRateDate CurrencyRateDate { get; set; }

    }
}
