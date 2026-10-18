using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class CustomerBankCheck
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; } = null!;
        public string? BankName { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuingDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Image { get; set; }
        public BankCheckStatus Status { get; set; }
        public Deposit Deposit { get; set; } = null!;
    }
}