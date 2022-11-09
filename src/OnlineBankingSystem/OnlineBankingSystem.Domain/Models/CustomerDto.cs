using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBankingSystem.Domain.Entities;

namespace OnlineBankingSystem.Domain.Models
{
    public class CustomerDto
    {
        public string? Id { get; set; }     // TODO: Temp: Id? for POST creation request

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength (50)]
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string ContactNumber { get; set; }

        [EmailAddress]
        // TODO: Add Unique constraint for DB
        public string EmailAddress { get; set; }

        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(9, MinimumLength = 9)]
        public string Ssn { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        // Collection navigation property
        public List<BankAccount>? BankAccounts { get; set; }

        // Collection navigation property
        public List<PersonalLoanApplication>? PersonalLoanApplications { get; set; }
    }
}
