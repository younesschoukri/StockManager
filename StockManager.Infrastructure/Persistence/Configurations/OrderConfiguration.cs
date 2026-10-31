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
            builder
                .HasOne(order => order.Customer)       // Order.HasOne(Customer)
                .WithMany(customer => customer.Orders) // Customer.WithMany(Orders)
                .HasForeignKey("CustomerId")           // Order.HasForeignKey("CustomerId").IsRequired()
                .IsRequired()                          // FK is required because an Order must be associated with a Customer.
                .OnDelete(DeleteBehavior.Restrict);    // Restrict deletion of Customer if it has associated Orders.

            // Order -> OrderDetails (One-to-Many)
            // An order can have many OrderDetails, but an OrderDetail must belong to one Order.
            builder
                .HasMany(order => order.OrderDetails)        // Order.HasMany(OrderDetails)
                .WithOne(orderDetails => orderDetails.Order) // OrderDetails.WithOne(Order)
                .HasForeignKey("OrderId")                    // OrderDetails.HasForeignKey("OrderId").IsRequired()
                .IsRequired()                                // FK is required because an OrderDetail must be associated with an Order.
                .OnDelete(DeleteBehavior.Restrict);          // Restrict deletion of an Order if it has associated OrderDetails.

            // Order -> Deposits (One-to-Many)
            // An order can have many Deposits, but a Deposit must belong to one Order.
            builder
                .HasMany(order => order.Deposits)   // Order.HasMany(Deposits)
                .WithOne(deposit => deposit.Order)  // Deposit.WithOne(Order)
                .HasForeignKey("OrderId")           // Deposit.HasForeignKey("OrderId").IsRequired()
                .IsRequired()                       // FK is required because a Deposit must be associated with an Order.
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion of an Order if it has associated Deposits.

            #endregion
        }
    }
}