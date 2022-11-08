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
        public Transaction(double amount, string? fromAccountId, string? toAccountId, string? comment)
        {
            Amount = amount;
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
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
        public string? FromAccountId { get; set; }
        // Reference navigation property
        public BankAccount? FromAccount { get; set; }

        // Foreign Key
        public string? ToAccountId { get; set; }
        // Reference navigation property
        public BankAccount? ToAccount { get; set; }

        public string? Comment { get; set; }
    }
}
