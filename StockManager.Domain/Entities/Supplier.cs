namespace StockManager.Domain.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Company { get; set; }
        public List<SupplierInformation>? Information { get; set; }
        public List<Supply>? Supplies { get; set; }
    }
}