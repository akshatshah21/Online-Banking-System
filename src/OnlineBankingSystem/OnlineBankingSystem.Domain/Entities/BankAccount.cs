using OnlineBankingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankingSystem.Domain.Entities
{
    public class BankAccount
    {
        [Key]
        public string AccountNumber { get; set; }

        // Foreign Key
        [Required]
        public string CustomerId { get; set; }
        // Reference navigation property
        public Customer customer { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public double MinBalance { get; set; }

        [Required]
        public double InterestRate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public BankAccountType Type { get; set; }

        [Required]
        public string RoutingNumber { get; set; }

        [InverseProperty("FromAccount")]
        public List<Transaction> SentTransactions { get; set; }

        [InverseProperty("ToAccount")]
        public List<Transaction> ReceivedTransactions { get; set; }

        [ForeignKey("Beneficiary")]
        public List<BankAccount> Beneficiaries { get; set; }
    }
}
