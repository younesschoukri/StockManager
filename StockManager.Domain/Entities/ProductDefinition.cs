namespace StockManager.Domain.Entities
{
    public class ProductDefinition
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal SuggestedRetailPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public string? Description { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
        public List<Supply> Supplies { get; set; } = null!;
        public List<ProductSpecification>? Specifications { get; set; }
    }
}