using OnlineBankingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankingSystem.Domain.Entities
{
    public class BankAccount
    {
        public BankAccount(string customerId, double balance, double minBalance, double interestRate, BankAccountType type, string routingNumber)
        {
            CustomerId = customerId;
            Balance = balance;
            MinBalance = minBalance;
            InterestRate = interestRate;
            Type = type;
            RoutingNumber = routingNumber;

            AccountNumber = Guid.NewGuid().ToString();
            SentTransactions = new List<Transaction>();
            ReceivedTransactions = new List<Transaction>();
            Beneficiaries = new List<BankAccount>();
            BeneficiaryOf = new List<BankAccount>();
            TransactionPin = generateTransactionPin();
        }

        [Key]
        public string AccountNumber { get; set; }

        // Foreign Key
        public string CustomerId { get; set; }
        // Reference navigation property
        public Customer customer { get; set; }

        public double Balance { get; set; }

        public double MinBalance { get; set; }

        public double InterestRate { get; set; }

        public DateTime CreatedAt { get; set; }

        public BankAccountType Type { get; set; }

        public string RoutingNumber { get; set; }

        [StringLength(4, MinimumLength = 4)]
        public string TransactionPin { get; set; }

        [InverseProperty("FromAccount")]
        public List<Transaction> SentTransactions { get; set; }

        [InverseProperty("ToAccount")]
        public List<Transaction> ReceivedTransactions { get; set; }

        public List<BankAccount> Beneficiaries { get; set; }

        public List<BankAccount> BeneficiaryOf { get; set; }

        private string generateTransactionPin()
        {
            string pin = "";
            for (int i = 0; i < 4; i++)
            {
                Random random = new Random();
                int digit = random.Next(0, 9);
                pin += digit.ToString();
            }
            return pin;
        }
    }
}
