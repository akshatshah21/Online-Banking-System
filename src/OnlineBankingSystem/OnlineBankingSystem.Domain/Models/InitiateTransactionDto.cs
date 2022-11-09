using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Models
{
    public class InitiateTransactionDto : TransactionDto
    {
        [StringLength(4, MinimumLength = 4)]
        public string? TransactionPin { get; set; }
    }
}
