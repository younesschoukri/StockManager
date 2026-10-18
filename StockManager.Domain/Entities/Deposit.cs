using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class Deposit
    {
        public Guid Id { get; set; }
        public DateTime AddingDate { get; set; }
        public PaymentMethod Payment { get; set; }
        public decimal? Amount { get; set; }
        public string? Note { get; set; }
        public Order Order { get; set; } = null!;
        public CustomerBankCheck? Check { get; set; }
    }
}