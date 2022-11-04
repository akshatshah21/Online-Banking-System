using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Entities
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength (50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        // TODO: Add Unique constraint for DB
        public string EmailAddress { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string Ssn { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        // Collection navigation property
        public List<BankAccount> BankAccounts { get; set; }

        // Collection navigation property
        public List<PersonalLoanApplication> PersonalLoanApplications { get; set; }
    }
}
