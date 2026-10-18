using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class SupplierInformation
    {
        public Guid Id { get; set; }
        public ContactType Type { get; set; }
        public string Details { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
    }
}