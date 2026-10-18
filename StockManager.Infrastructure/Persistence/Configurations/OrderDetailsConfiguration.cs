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

            // OrderDetails -> Order
            // An order can have many detail records, but each detail record belongs to one order.
            builder
                .HasOne(orderDetails => orderDetails.Order)
                .WithMany(order => order.OrderDetails)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // OrderDetails -> Products
            // An order detail can contain multiple products, a product may belong to zero or one order detail.
            builder
                .HasMany(details => details.Products)
                .WithOne(product => product.OrderDetails)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}