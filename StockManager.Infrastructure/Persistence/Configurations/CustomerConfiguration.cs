using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region Table Name

            // Table name
            builder
                .ToTable("Customers");

            #endregion

            #region Properties

            #region Id

            // Set Id as the primary key
            builder
                .HasKey(customer => customer.Id);

            // Set the Id to be auto generated
            builder
                .Property(customer => customer.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Name

            // Name is required with max length of 100 characters.
            builder
                .Property(customer => customer.Name)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Description

            // Description is optional with a max length of 500 characters.
            builder
                .Property(customer => customer.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            #endregion

            #region AddingDate

            // AddingDate is required with a default value
            builder
                .Property(customer => customer.AddingDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            #endregion

            #endregion

            #region Relationships

            // Customer -> Orders (One-to-Many)
            // One customer can have many orders, and each order must belong to one customer.
            builder
                .HasMany(customer => customer.Orders) // Customer.HasMany(Orders)
                .WithOne(order => order.Customer)     // Order.HasOne(Customer)
                .HasForeignKey("CustomerId")          // Order.HasForeignKey("CustomerId").IsRequired()
                .IsRequired()                         // FK is required because an Order must be associated with a Customer.
                .OnDelete(DeleteBehavior.Restrict);   // Restrict deletion of Customer if it has associated Orders.

            // Customer -> CustomerInformation (One-to-Many)
            // One customer can have many customer information records, and each customer information record must belong to one customer.
            builder
                .HasMany(customer => customer.CustomerInformation)            // Customer.HasMany(CustomerInformation)
                .WithOne(customerInformation => customerInformation.Customer) // CustomerInformation.HasOne(Customer)
                .HasForeignKey("CustomerId")                                  // CustomerInformation.HasForeignKey("CustomerId").IsRequired()
                .IsRequired()                                                 // FK is required because a CustomerInformation must be associated with a Customer.
                .OnDelete(DeleteBehavior.Restrict);                           // Restrict deletion of Customer if it has associated CustomerInformation records.

            #endregion
        }
    }
}