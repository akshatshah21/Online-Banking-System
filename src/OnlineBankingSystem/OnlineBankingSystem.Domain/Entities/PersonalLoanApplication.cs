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
        [Key]
        public string Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double InterestRate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Term { get; set; }

        // Foreign Key
        [Required]
        public string CustomerId { get; set; }
        // Reference navigation property
        public Customer Customer { get; set; }

        [Required]
        public DateOnly ApplicationDate { get; set; }

        public DateOnly ApprovalDate { get; set; }

        [Required]
        public PersonalLoanApplicationStatus status { get; set; }
    }
}
