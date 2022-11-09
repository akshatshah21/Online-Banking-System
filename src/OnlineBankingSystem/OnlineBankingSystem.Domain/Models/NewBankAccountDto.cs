using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Models
{
    public class NewBankAccountDto: BankAccountDto
    {
        public string TransactionPIN { get; set; }
    }
}
