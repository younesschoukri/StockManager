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

            // Customer -> Orders:
            // One customer can have many orders, and each order belongs to one customer.
            builder
                .HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer)
                .IsRequired();

            // Customer -> CustomerInformation:
            // One customer can have many customer information entries, and each customer information entry belongs to one customer.
            builder
                .HasMany(customer => customer.CustomerInformation)
                .WithOne(customerInformation => customerInformation.Customer)
                .IsRequired();

            #endregion
        }
    }
}