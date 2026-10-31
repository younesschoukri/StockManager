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

            // SubCategory -> Category (Many-to-One)
            // A category can have multiple subcategories, but each subcategory must belong to one category.
            builder
                .HasOne(subCategory => subCategory.Category)  // SubCategory.HasOne(Category)
                .WithMany(category => category.SubCategories) // Category.HasMany(SubCategories)
                .HasForeignKey("CategoryId")                  // SubCategory.HasForeignKey("CategoryId").IsRequired()
                .IsRequired()                                 // FK is required because a SubCategory must be associated with a Category 
                .OnDelete(DeleteBehavior.Restrict);           // Restrict deletion of Category if it has associated SubCategories.

            // SubCategory -> ProductDefinitions (One-to-Many).
            // A subcategory can have multiple product definitions, but a product definition must belong to one subcategory.
            builder
                .HasMany(subCategory => subCategory.ProductDefinitions) // SubCategory.HasMany(ProductDefinitions)
                .WithOne(definition => definition.SubCategory)          // ProductDefinition.HasOne(SubCategory)
                .HasForeignKey("SubCategoryId")                         // ProductDefinition.HasForeignKey("SubCategoryId").IsRequired()
                .IsRequired()                                           // FK is required because a ProductDefinition must be associated with a SubCategory.
                .OnDelete(DeleteBehavior.Restrict);                     // Restrict deletion of a SubCategory if it has associated ProductDefinitions.

            #endregion
        }
    }
}