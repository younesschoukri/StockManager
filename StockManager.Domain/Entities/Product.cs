using StockManager.Domain.Enums;

namespace StockManager.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? SerialNumber { get; set; }
        public decimal CostPrice { get; set; }
        public decimal? FirstRecommendedPrice { get; set; }
        public decimal? LastFinalPrice { get; set; }
        public decimal? SoldPrice { get; set; }
        public DateTime AddingDate { get; set; }
        public int Quantity { get; set; }
        public ProductState State { get; set; }
        public string? QRCode { get; set; }
        public string? Note { get; set; }
        public Supply Supply { get; set; } = null!;
        public ProductDefinition ProductDefinition { get; set; } = null!;
        public OrderDetails? OrderDetails { get; set; }
    }
}