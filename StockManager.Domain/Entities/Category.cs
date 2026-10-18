namespace StockManager.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
    }
}