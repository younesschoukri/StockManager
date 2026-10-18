using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class Supply
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public string? InvoiceImage { get; set; }
        public PaymentMethod? Payment { get; set; }
        public OrderStatus Status { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
        public List<ProductDefinition> ProductDefinitions { get; set; } = null!;
        public List<CompanyBankCheck>? CompanyBankChecks { get; set; }
    }
}