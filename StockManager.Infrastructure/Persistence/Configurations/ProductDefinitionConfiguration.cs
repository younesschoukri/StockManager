using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class ProductDefinitionConfiguration : IEntityTypeConfiguration<ProductDefinition>
    {
        public void Configure(EntityTypeBuilder<ProductDefinition> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("ProductDefinitions");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(definition => definition.Id);

            // Id configuration
            builder
                .Property(definition => definition.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Name

            // Name configuration
            builder
                .Property(definition => definition.Name)
                .IsRequired()
                .HasMaxLength(200);

            #endregion

            #region SKU

            // SKU configuration
            builder
                .Property(definition => definition.SKU)
                .IsRequired()
                .HasMaxLength(100);

            // Unique SKU
            builder
                .HasIndex(definition => definition.SKU)
                .IsUnique();

            #endregion

            #region Brand

            // Brand configuration
            builder
                .Property(definition => definition.Brand)
                .HasMaxLength(100)
                .IsRequired(false);

            #endregion

            #region Model

            // Model configuration
            builder
                .Property(definition => definition.Model)
                .HasMaxLength(100)
                .IsRequired(false);

            #endregion

            #region SuggestedRetailPrice

            // SuggestedRetailPrice configuration
            builder
                .Property(definition => definition.SuggestedRetailPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            #endregion

            #region FinalPrice

            // FinalPrice configuration
            builder
                .Property(definition => definition.FinalPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            #endregion

            #region Description

            // Description configuration
            builder
                .Property(definition => definition.Description)
                .HasMaxLength(2000)
                .IsRequired(false);

            #endregion

            #endregion

            #region Relationships

            // ProductDefinition -> Products (One-to-Many)
            // A product definition can describe multiple physical products, a product can belong to only one product definition.
            builder
                .HasMany(definition => definition.Products)
                .WithOne(product => product.ProductDefinition)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ProductDefinition -> Specifications (One-to-Many)
            // A product definition may or may not have multiple specifications, a specification can belong to only one product definition.
            builder
                .HasMany(definition => definition.Specifications)
                .WithOne(specification => specification.ProductDefinition)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ProductDefinition -> SubCategory (Many-to-One)
            // A product definition must belong to exactly one subcategory, a subcategory can have multiple product definitions.
            builder
                .HasOne(definition => definition.SubCategory)
                .WithMany(subCategory => subCategory.ProductDefinitions)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ProductDefinition -> Supply (Many-to-Many)
            // A product definition can appear in multiple supplies.
            // A supply can contain multiple product definitions.
            builder
                .HasMany(definition => definition.Supplies)
                .WithMany(supply => supply.ProductDefinitions)
                .UsingEntity("SupplyProductDefinitions");

            #endregion
        }
    }
}