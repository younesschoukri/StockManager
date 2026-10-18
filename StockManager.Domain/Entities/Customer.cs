namespace StockManager.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime AddingDate { get; }
        public List<Order>? Orders { get; set; }
        public List<CustomerInformation>? CustomerInformation { get; set; }
    }
}