namespace StockManager.Domain.Entities
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string? Note { get; set; }
        public Order Order { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
    }
}