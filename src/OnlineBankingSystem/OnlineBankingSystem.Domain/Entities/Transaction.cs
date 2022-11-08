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
        public Transaction(double amount, DateTime timestamp, string? fromAccountId, BankAccount? fromAccount, string? toAccountId, BankAccount? toAccount, string? comment)
        {
            Amount = amount;
            Timestamp = timestamp;
            FromAccountId = fromAccountId;
            FromAccount = fromAccount;
            ToAccountId = toAccountId;
            ToAccount = toAccount;
            Comment = comment;

            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        public DateTime Timestamp { get; set; }

        // Foreign Key
        [Required]
        public string FromAccountId { get; set; }
        // Reference navigation property
        public BankAccount FromAccount { get; set; }

        // Foreign Key
        [Required]
        public string ToAccountId { get; set; }
        // Reference navigation property
        public BankAccount ToAccount { get; set; }

        public string? Comment { get; set; }
    }
}
