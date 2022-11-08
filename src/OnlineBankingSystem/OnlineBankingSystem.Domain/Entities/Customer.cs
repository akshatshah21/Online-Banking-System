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
        public Customer(string password, string firstName, string lastName, string contactNumber, string emailAddress, string address, DateTime dateOfBirth, string ssn, List<BankAccount> bankAccounts, List<PersonalLoanApplication> personalLoanApplications)
        {
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            Address = address;
            DateOfBirth = dateOfBirth;
            Ssn = ssn;
            BankAccounts = bankAccounts;
            PersonalLoanApplications = personalLoanApplications;

            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            ModifiedAt = CreatedAt;
            BankAccounts = new List<BankAccount>();     // TODO
            PersonalLoanApplications = new List<PersonalLoanApplication>():
        }

        [Key]
        public string Id { get; set; }

        public string Password { get; set; }

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

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        // Collection navigation property
        public List<BankAccount> BankAccounts { get; set; }

        // Collection navigation property
        public List<PersonalLoanApplication> PersonalLoanApplications { get; set; }
    }
}
