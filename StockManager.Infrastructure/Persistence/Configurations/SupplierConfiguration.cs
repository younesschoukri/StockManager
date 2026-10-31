using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            #region Table Name

            // Configure the table name
            builder.ToTable("Suppliers");

            #endregion

            #region Properties

            #region Id

            // Configure the primary key
            builder.HasKey(supplier => supplier.Id);

            // Configure the primary key to be generated automatically
            builder.Property(supplier => supplier.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Name

            // Configure the supplier's name
            builder.Property(supplier => supplier.Name)
                .IsRequired()
                .HasMaxLength(200);

            #endregion

            #region Company

            // Configure the supplier's company
            builder.Property(supplier => supplier.Company)
                .IsRequired(false)
                .HasMaxLength(200);

            #endregion

            #endregion

            #region Relationships

            // Supplier -> Supply (One-to-Many)
            // A supplier can have zero or multiple supplies, a supply must belong to one supplier.
            builder
                .HasMany(supplier => supplier.Supplies) // Supplier.HasMany(Supplies)
                .WithOne(supply => supply.Supplier)     // Supply.HasOne(Supplier)
                .HasForeignKey("SupplierId")            // Supply.HasForeigKey("SupplierId")
                .IsRequired()                           // FK is required because a Supply must be associated with a Supplier.
                .OnDelete(DeleteBehavior.Restrict);     // Restrict deletion of a Supplier if it has associated Supplies.

            // Supplier -> SupplierInformation (One-to-Many)
            // A supplier can have zero or multiple information records, a supplier information record must belong to one supplier.
            builder
                .HasMany(supplier => supplier.Information)    // Supplier.HasMany(SupplierInformation)
                .WithOne(information => information.Supplier) // SupplierInformation.HasOne(Supplier)
                .HasForeignKey("SupplierId")                  // SupplierInformation.HasForeignKey("SupplierId")
                .IsRequired()                                 // FK is required because a SupplierInformation must be associated with a Supplier.
                .OnDelete(DeleteBehavior.Restrict);           // Restrict deletion of a Supplier if it has associated SupplierInformation.

            #endregion
        }
    }
}