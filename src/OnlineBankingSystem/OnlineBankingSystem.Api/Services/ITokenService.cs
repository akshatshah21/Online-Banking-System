using OnlineBankingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Api.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, CustomerDto customer);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
