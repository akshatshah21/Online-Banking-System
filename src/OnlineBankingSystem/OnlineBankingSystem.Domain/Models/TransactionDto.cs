using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Models
{
    public class TransactionDto
    {
        public string? Id { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        public DateTime? Timestamp { get; set; }

        public string FromAccountNumber { get; set; }

        public string ToAccountNumber { get; set; }

        public string? Comment { get; set; }
    }
}
