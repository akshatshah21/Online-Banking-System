using OnlineBankingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Entities
{
    public class PersonalLoanApplication
    {
        public PersonalLoanApplication(double amount, double interestRate, int term, string customerId)
        {
            Amount = amount;
            InterestRate = interestRate;
            Term = term;
            CustomerId = customerId;

            Id = Guid.NewGuid().ToString();
            ApplicationDate = DateTime.Now;
            status = PersonalLoanApplicationStatus.PENDING;
        }

        [Key]
        public string Id { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        [Range(0, double.MaxValue)]
        public double InterestRate { get; set; }

        [Range(0, int.MaxValue)]
        public int Term { get; set; }

        // Foreign Key
        public string CustomerId { get; set; }
        // Reference navigation property
        public Customer Customer { get; set; }

        [DisplayFormat(DataFormatString = "0:{MM/dd/yyyy}")]
        public DateTime ApplicationDate { get; set; }

        [DisplayFormat(DataFormatString = "0:{MM/dd/yyyy}")]
        public DateTime ApprovalDate { get; set; }

        public PersonalLoanApplicationStatus status { get; set; }
    }
}
