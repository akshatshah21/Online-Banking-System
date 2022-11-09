using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Models
{
    public class BeneficiaryDto
    {
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        public BeneficiaryDto(string accountNumber, string routingNumber)
        {
            AccountNumber = accountNumber;
            RoutingNumber = routingNumber;
        }
    }
}
