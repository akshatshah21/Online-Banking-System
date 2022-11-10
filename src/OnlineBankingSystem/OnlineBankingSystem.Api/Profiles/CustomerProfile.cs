using AutoMapper;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Api.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.BankAccounts, op => op.MapFrom<CustomerBankAccountsResolver>())
                .ReverseMap()
                    .ForMember(c => c.Password, password => password.Ignore())
                    .ForMember(c => c.Id, id => id.Ignore())
                    .ForMember(c => c.CreatedAt, createdAt => createdAt.Ignore())
                    .ForMember(c => c.ModifiedAt, modifiedAt => modifiedAt.Ignore())
                    .ForMember(c => c.BankAccounts, op => op.Ignore())
                    .ForMember(c => c.PersonalLoanApplications, loanApplications => loanApplications.Ignore());

        }
    }

    public class CustomerBankAccountsResolver : IValueResolver<Customer, CustomerDto, List<string>>
    {
        public List<string> Resolve(Customer source, CustomerDto destination, List<string> destMember, ResolutionContext context)
        {
            return source.BankAccounts.Select(b => b.AccountNumber).ToList();
        }
    }
}
