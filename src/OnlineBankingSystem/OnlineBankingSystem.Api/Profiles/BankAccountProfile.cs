using AutoMapper;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Domain.Enums;
using OnlineBankingSystem.Domain.Models;

namespace OnlineBankingSystem.Api.Profiles
{
    public class BankAccountProfile : Profile
    {

        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountDto>()
                .ForMember(b => b.Type, op => op.MapFrom(src => getAccountTypeString(src.Type)))
                .ReverseMap()
                    .ForMember(b => b.AccountNumber, op => op.Ignore())
                    .ForMember(b => b.CreatedAt, op => op.Ignore())
                    .ForMember(b => b.Type, op => op.MapFrom(src => getAccountTypeEnum(src.Type)));
        }

        private string getAccountTypeString(BankAccountType type) => type switch
        {
            BankAccountType.SAVINGS => "Savings",
            BankAccountType.CURRENT => "Current",
            _ => ""
        };

        private BankAccountType getAccountTypeEnum(string type) => type.ToLower() switch
        {
            "savings" => BankAccountType.SAVINGS,
            "current" => BankAccountType.CURRENT,
            _ => BankAccountType.SAVINGS        // TODO: Temp
        };
    }
}

