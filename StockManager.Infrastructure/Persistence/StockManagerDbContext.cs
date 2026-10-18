using Microsoft.EntityFrameworkCore;

namespace StockManager.Infrastructure.Persistence
{
    public class StockManagerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerInformation> CustomersInformation { get; set; } = null!;
        public DbSet<CustomerBankCheck> CustomersBankChecks { get; set; } = null!;
        public DbSet<CompanyBankCheck> CompanyBankChecks { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductDefinition> ProductsDefinitions { get; set; } = null!;
        public DbSet<ProductSpecification> ProductsSpecifications { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<SubCategory> SubCategories { get; set; } = null!;
        public DbSet<Deposit> Deposits { get; set; } = null!;
        public DbSet<Supply> Supplies { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<SupplierInformation> SuppliersInformation { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockManagerDbContext).Assembly);
        }
    }
}