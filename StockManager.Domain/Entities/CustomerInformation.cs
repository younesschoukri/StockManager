using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class CustomerInformation
    {
        public Guid Id { get; set; }
        public ContactType Type { get; set; }
        public string Details { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}