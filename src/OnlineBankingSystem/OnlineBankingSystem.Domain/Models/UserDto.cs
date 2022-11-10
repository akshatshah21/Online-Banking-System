using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem.Domain.Models
{
    public class UserDto 
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public List<string>? bankAccounts { get; set; }
    }
}
