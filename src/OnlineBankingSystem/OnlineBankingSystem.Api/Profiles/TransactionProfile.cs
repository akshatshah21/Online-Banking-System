using AutoMapper;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Domain.Models;

namespace OnlineBankingSystem.Api.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>()
                .ReverseMap()
                    .ForMember(t => t.Id, op => op.Ignore())
                    .ForMember(t => t.Timestamp, op => op.Ignore());
        }
    }
}
