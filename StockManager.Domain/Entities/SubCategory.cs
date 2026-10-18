namespace StockManager.Domain.Entities
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Category Category { get; set; } = null!;
        public List<ProductDefinition>? ProductDefinitions { get; set; }
    }
}