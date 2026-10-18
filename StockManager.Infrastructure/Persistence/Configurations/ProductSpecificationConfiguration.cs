using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            #region Table Name

            // Configure the table name
            builder.ToTable("ProductSpecifications");

            #endregion

            #region Properties

            #region Id

            // Configure the primary key
            builder.HasKey(specification => specification.Id);

            // Configure the primary key to be generated automatically
            builder.Property(specification => specification.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Name

            // Configure the specification name
            builder.Property(specification => specification.Name)
                .IsRequired()
                .HasMaxLength(150);

            #endregion

            #region Value

            // Configure the specification value
            builder.Property(specification => specification.Value)
                .IsRequired()
                .HasMaxLength(500);

            #endregion

            #endregion

            #region Relationship

            // specifications -> ProductDefinition
            // A ProductDefinition can have multiple specifications, a ProductSpecification must belong to one ProductDefinition.
            builder.HasOne(specification => specification.ProductDefinition)
                .WithMany(definition => definition.Specifications)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}