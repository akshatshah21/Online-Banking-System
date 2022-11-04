using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBankingSystem.Domain.Entities;

namespace OnlineBankingSystem.Persistence.Data
{
    public class OnlineBankingSystemDbContext : DbContext 
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PersonalLoanApplication> PersonalLoanApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
        }
    }
}
