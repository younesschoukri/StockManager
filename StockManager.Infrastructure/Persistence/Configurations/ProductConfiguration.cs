using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("Products");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(product => product.Id);

            // Id configuration
            builder
                .Property(product => product.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region SerialNumber

            // SerialNumber configuration
            builder
                .Property(product => product.SerialNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            #endregion

            #region CostPrice

            // CostPrice configuration
            builder
                .Property(product => product.CostPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            #endregion

            #region FirstRecommendedPrice

            // FirstRecommendedPrice configuration
            builder
                .Property(product => product.FirstRecommendedPrice)
                .HasPrecision(18, 2)
                .IsRequired(false);

            #endregion

            #region LastFinalPrice

            // LastFinalPrice configuration
            builder
                .Property(product => product.LastFinalPrice)
                .HasPrecision(18, 2)
                .IsRequired(false);

            #endregion

            #region SoldPrice

            // SoldPrice configuration
            builder
                .Property(product => product.SoldPrice)
                .HasPrecision(18, 2)
                .IsRequired(false);

            #endregion

            #region AddingDate

            // AddingDate configuration
            builder
                .Property(product => product.AddingDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            #endregion

            #region Quantity

            // Quantity configuration
            builder
                .Property(product => product.Quantity)
                .IsRequired();

            #endregion

            #region State

            // State configuration
            builder
                .Property(product => product.State)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #region QRCode

            // QRCode configuration
            builder
                .Property(product => product.QRCode)
                .HasMaxLength(500)
                .IsRequired(false);

            #endregion

            #region Note

            // Note configuration
            builder
                .Property(product => product.Note)
                .HasMaxLength(1000)
                .IsRequired(false);

            #endregion

            #endregion

            #region Relationships

            // Product -> Supply (Many-to-One)
            // A supply can have many products, but a product belongs to one supply.
            builder
                .HasOne(product => product.Supply)   // Product.HasOne(Supply)
                .WithMany(supply => supply.Products) // Supply.HasMany(Product)
                .HasForeignKey("SupplyId")           // Product.HasForeignKey("SupplyId").IsRequired()
                .IsRequired()                        // FK is required because a product must be associated with a supply.
                .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of a Supply if it has associated Products.

            // Product -> ProductDefinition (Many-to-One)
            // A product definition can describe many products, but each product has only one product definition.
            builder
                .HasOne(product => product.ProductDefinition) // Product.HasOne(ProductDefinition)
                .WithMany(definition => definition.Products)  // ProductDefinition.HasMany(Product)
                .HasForeignKey("ProductDefinitionId")         // Product.HasForeignKey("ProductDefinitionId")
                .IsRequired()                                 // FK is required because a Product must be associated with a ProductDefinition.
                .OnDelete(DeleteBehavior.Restrict);           // Restrict deletion of a ProductDefinition if it has associated Products.

            // Product -> OrderDetails (Many-to-One)
            // A product may not have been sold yet, so its OrderDetails relationship is optional.
            builder
                .HasOne(product => product.OrderDetails) // Product.HasOne(OrderDetails)
                .WithMany(details => details.Products)   // OrderDetails.HasMany(Product)
                .HasForeignKey("OrderDetailsId")         // Product.HasForeignKey("OrderDetailsId").IsOptional()
                .IsRequired(false)                       // FK is optional because a Product may not be associated with an OrderDetails yet.
                .OnDelete(DeleteBehavior.Restrict);      // Restrict deletion of an OrderDetails if it has associated Products.

            #endregion
        }
    }
}