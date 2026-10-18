using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("Categories");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(category => category.Id);

            // Id configuration
            builder
                .Property(category => category.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Name

            // Name configuration
            builder
                .Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(150);

            // The category name must be unique
            builder
                .HasIndex(category => category.Name)
                .IsUnique();

            #endregion

            #region Description

            // Description configuration
            builder
                .Property(category => category.Description)
                .HasMaxLength(1000)
                .IsRequired(false);

            #endregion

            #endregion

            #region Relationship

            // Category -> SubCategories
            // A category can have multiple subcategories, a subcategory must belong to one category.
            builder
                .HasMany(category => category.SubCategories)
                .WithOne(subCategory => subCategory.Category)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}