using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class SupplierInformationConfiguration : IEntityTypeConfiguration<SupplierInformation>
    {
        public void Configure(EntityTypeBuilder<SupplierInformation> builder)
        {
            #region Table Name

            // Configure the table name
            builder.ToTable("SupplierInformation");

            #endregion

            #region Properties

            #region Id

            // Configure the primary key
            builder.HasKey(supplierInformation => supplierInformation.Id);

            // Configure the primary key to be generated automatically
            builder.Property(supplierInformation => supplierInformation.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region ContactType

            // Configure the contact information type
            // Store the enum as an integer in the database.
            builder.Property(supplierInformation => supplierInformation.Type)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #region Details

            // Configure the contact details
            builder.Property(supplierInformation => supplierInformation.Details)
                .IsRequired()
                .HasMaxLength(500);

            #endregion

            #endregion

            #region Relationship

            // SupplierInformation -> Supplier (Many-to-One)
            // A supplier can have multiple information records, a supplier information record must belong to exactly one supplier.
            builder
                .HasOne(supplierInformation => supplierInformation.Supplier)
                .WithMany(supplier => supplier.Information)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}