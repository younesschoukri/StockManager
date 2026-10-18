using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class CompanyBankCheck
    {
        public Guid Id { get; set; }
        public string Owner { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public decimal Amount { get; set; }
        public string? Image { get; set; }
        public DateTime? DueDate { get; set; }
        public BankCheckStatus Status { get; set; }
        public Supply Supply { get; set; } = null!;
    }
}