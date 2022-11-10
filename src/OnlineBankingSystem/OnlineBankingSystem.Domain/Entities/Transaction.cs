using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Entities
{
    public class Transaction
    {
        public Transaction(double amount, string? fromAccountNumber, string? toAccountNumber, string? comment)
        {
            Amount = amount;
            FromAccountNumber = fromAccountNumber;
            ToAccountNumber = toAccountNumber;
            Comment = comment;

            Id = Guid.NewGuid().ToString();
            Timestamp = DateTime.Now;
        }

        [Key]
        public string Id { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        public DateTime Timestamp { get; set; }

        // Foreign Key
        [ForeignKey("FromAccountNumber")]
        public string? FromAccountNumber { get; set; }
        // Reference navigation property
        public BankAccount? FromAccount { get; set; }

        // Foreign Key
        [ForeignKey("ToAccountNumber")]
        public string? ToAccountNumber { get; set; }
        // Reference navigation property
        public BankAccount? ToAccount { get; set; }

        public string? Comment { get; set; }
    }
}
