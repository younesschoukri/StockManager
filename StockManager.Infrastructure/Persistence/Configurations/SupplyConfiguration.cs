using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            #region Table Name

            // Configure the table name
            builder.ToTable("Supplies");

            #endregion

            #region Properties

            #region Id

            // Configure the primary key
            builder.HasKey(supply => supply.Id);

            // Configure the primary key to be generated automatically
            builder.Property(supply => supply.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Total

            // Configure the total supply cost
            builder.Property(supply => supply.Total)
                .IsRequired()
                .HasPrecision(18, 2);

            #endregion

            #region Date

            // Configure the supply date
            // Use the database UTC time when no date is supplied.
            builder.Property(supply => supply.AddingDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            #endregion

            #region InvoiceImage

            // Configure the invoice image path or URL
            builder.Property(supply => supply.InvoiceImage)
                .IsRequired(false)
                .HasMaxLength(500);

            #endregion

            #region Payment

            // Configure the payment method
            // Null-able because payment may not have been recorded yet.
            builder.Property(supply => supply.Payment)
                .IsRequired(false)
                .HasConversion<int>();

            #endregion

            #region Status

            // Configure the supply status
            // Store the enum as an integer.
            builder.Property(supply => supply.Status)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #endregion

            #region Relationships

            // Supply -> Supplier (Many-to-One)
            // A supplier can have multiple supplies, a supply must belong to exactly one supplier.
            builder
                .HasOne(supply => supply.Supplier)
                .WithMany(supplier => supplier.Supplies)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Supply -> Product (Many-to-One)
            // A supply can contain multiple physical products, a product must belong to one supply.
            builder
                .HasMany(supply => supply.Products)
                .WithOne(product => product.Supply)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Supply -> CompanyBankChecks (Many-to-One)
            // A supply can have zero or multiple checks, a company check must belong to one supply.
            builder
                .HasMany(supply => supply.CompanyBankChecks)
                .WithOne(check => check.Supply)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Supply -> ProductDefinition (Many-to-Many)
            // A supply can contain multiple product definitions, a product definition can appear in multiple supplies.
            builder
                .HasMany(supply => supply.ProductDefinitions)
                .WithMany(definition => definition.Supplies)
                .UsingEntity("SupplyProductDefinitions");

            #endregion
        }
    }
}