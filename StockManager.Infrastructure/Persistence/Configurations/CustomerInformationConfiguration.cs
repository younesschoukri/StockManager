using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class CustomerInformationConfiguration : IEntityTypeConfiguration<CustomerInformation>
    {
        public void Configure(EntityTypeBuilder<CustomerInformation> builder)
        {
            #region Table Name

            // Table name
            builder
                .ToTable("CustomerInformation");

            #endregion

            #region Properties

            #region Id

            // Set Id as the primary key
            builder
                .HasKey(customerInformation => customerInformation.Id);

            // Set the Id to be auto generated
            builder
                .Property(customerInformation => customerInformation.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Type

            // Contact type must be required and stored as an integer in the database
            builder
                .Property(customerInformation => customerInformation.Type)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #region Details

            // Details must be required with a max length of 500 characters
            builder
                .Property(customerInformation => customerInformation.Details)
                .IsRequired()
                .HasMaxLength(500);

            #endregion

            #endregion

            #region Relationship

            // CustomerInformation -> Customer (Many-to-One)
            // A CustmerInformation belongs to one customer, and a customer can have many CustomerInformation.
            builder
                .HasOne(customerInformation => customerInformation.Customer) // CustomerInformation.HasOne(Customer)
                .WithMany(customer => customer.CustomerInformation)          // Customer.HasMany(CustomerInformation)
                .HasForeignKey("CustomerId")                                 // CustomerInformation.HasForeignKey("CustomerId").IsRequired()
                .IsRequired()                                                // FK is required because a CustomerInformation must be associated with a Customer.
                .OnDelete(DeleteBehavior.Restrict);                          // Restrict deletion of a customer if there are associated CustomerInformation records.

            #endregion
        }
    }
}