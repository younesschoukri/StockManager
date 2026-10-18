namespace StockManager.Domain.Entities
{
    public class ProductSpecification
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public ProductDefinition ProductDefinition { get; set; } = null!;
    }
}