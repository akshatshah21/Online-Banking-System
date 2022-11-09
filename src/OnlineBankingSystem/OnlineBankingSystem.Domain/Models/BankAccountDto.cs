namespace OnlineBankingSystem.Domain.Models
{
    public class BankAccountDto
    {
        public string? AccountNumber { get; set; }

        public string CustomerId { get; set; }

        public double Balance { get; set; }

        public double MinBalance { get; set; }

        public double InterestRate { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Type { get; set; }

        public string RoutingNumber { get; set; }
    }
}
