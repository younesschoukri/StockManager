using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("SubCategories");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(subCategory => subCategory.Id);

            // Id configuration
            builder
                .Property(subCategory => subCategory.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Name

            // Name configuration
            builder
                .Property(subCategory => subCategory.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(subCategory => subCategory.Name).IsUnique();

            // Unique name within a category
            builder
                .HasIndex("CategoryId", nameof(SubCategory.Name))
                .IsUnique();

            #endregion

            #region Description

            // Description configuration
            builder
                .Property(subCategory => subCategory.Description)
                .HasMaxLength(1000)
                .IsRequired(false);

            #endregion

            #endregion

            #region Relationships

            // SubCategory -> Category
            // A category can have multiple subcategories, but each subcategory must belong to one category.
            builder
                .HasOne(subCategory => subCategory.Category)
                .WithMany(category => category.SubCategories)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // SubCategory -> ProductDefinitions
            // A subcategory can have multiple product definitions, but a product definition must belong to one subcategory.
            builder
                .HasMany(subCategory => subCategory.ProductDefinitions)
                .WithOne(definition => definition.SubCategory)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}