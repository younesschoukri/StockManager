using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime AddingDate { get; }
        public OrderStatus Status { get; set; }
        public string? Note { get; set; }
        public Customer Customer { get; set; } = null!;
        public List<OrderDetails> OrderDetails { get; set; } = null!;
        public List<Deposit>? Deposits { get; set; }
    }
}