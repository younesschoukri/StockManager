using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("Orders");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(order => order.Id);

            // Id configuration
            builder
                .Property(order => order.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region AddingDate

            // AddingDate configuration
            builder
                .Property(order => order.AddingDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            #endregion

            #region Status

            // Status configuration
            builder
                .Property(order => order.Status)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #region Note

            // Note configuration
            builder
                .Property(order => order.Note)
                .HasMaxLength(1000)
                .IsRequired(false);

            #endregion

            #endregion

            #region Relationships

            // Order -> Customer (Many-to-One)
            // Customer can have many Orders, but an Order must have one Customer.
            // Deleting a Customer will not delete their Orders (Restrict).
            builder
                .HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Order -> OrderDetails (One-to-Many)
            // An order can have many OrderDetails, but an OrderDetail must belong to one Order.
            // Deleting an Order will not delete its OrderDetails (Restrict).
            builder
                .HasMany(order => order.OrderDetails)
                .WithOne(orderDetails => orderDetails.Order)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Order -> Deposits (One-to-Many)
            // An order can have many Deposits, but a Deposit must belong to one Order.
            // Deleting an Order will not delete its Deposits (Restrict).
            builder
                .HasMany(order => order.Deposits)
                .WithOne(deposit => deposit.Order)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}