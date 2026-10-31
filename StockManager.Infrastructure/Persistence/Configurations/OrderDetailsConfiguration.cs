using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("OrderDetails");

            #endregion

            #region Properties

            // Primary key
            builder
                .HasKey(details => details.Id);

            // Id configuration
            builder
                .Property(details => details.Id)
                .ValueGeneratedOnAdd();

            // AddedDate configuration
            builder
                .Property(details => details.AddingDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Note configuration
            builder
                .Property(details => details.Note)
                .HasMaxLength(1000)
                .IsRequired(false);

            #endregion

            #region Relationships

            // OrderDetails -> Order (Many-to-One)
            // An order can have many detail records, but each detail record belongs to one order.
            builder
                .HasOne(orderDetails => orderDetails.Order) // OrderDetails.HasOne(Order)
                .WithMany(order => order.OrderDetails)      // Order.HasMany(OrderDetails)
                .HasForeignKey("OrderId")                   // OrderDetails.HasForeignKey("OrderId").IsRequired()
                .IsRequired()                               // FK is required because an OrderDetails must be associated with an Order.
                .OnDelete(DeleteBehavior.Restrict);         // Restrict deletion of an Order if it has associated OrderDetails.

            // OrderDetails -> Products (One-to-Many)
            // An order detail can contain multiple products, a product may belong to zero or one order detail.
            builder
                .HasMany(details => details.Products)     // OrderDetails.HasMany(Products)
                .WithOne(product => product.OrderDetails) // Product.HasOne(OrderDetails)
                .HasForeignKey("OrderDetailsId")          // Product.HasForeignKey("OrderDetailsId").IsOptional()
                .IsRequired(false)                        // FK is optional because a product can exist without being associated with an OrderDetails, simply because it hasn't been purchased yet.
                .OnDelete(DeleteBehavior.Restrict);       // Restrict deletion of an OrderDetails if it has associated Products.

            #endregion
        }
    }
}