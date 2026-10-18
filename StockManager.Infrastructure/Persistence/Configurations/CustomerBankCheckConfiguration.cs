using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class CustomerBankCheckConfiguration : IEntityTypeConfiguration<CustomerBankCheck>
    {
        public void Configure(EntityTypeBuilder<CustomerBankCheck> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("CustomerBankChecks");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(check => check.Id);

            // Id configuration
            builder
                .Property(check => check.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region OwnerName

            // OwnerName configuration
            builder
                .Property(check => check.OwnerName)
                .IsRequired()
                .HasMaxLength(150);

            #endregion

            #region BankName

            // BankName configuration
            builder
                .Property(check => check.BankName)
                .HasMaxLength(150)
                .IsRequired(false);

            #endregion

            #region Amount

            // Amount configuration
            builder
                .Property(check => check.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            #endregion

            #region IssueDate

            // IssuedDate configuration
            builder
                .Property(check => check.IssuingDate)
                .IsRequired();

            #endregion

            #region DueDate

            // DueDate configuration
            builder
                .Property(check => check.DueDate)
                .IsRequired(false);

            #endregion

            #region Image

            // Image configuration
            builder
                .Property(check => check.Image)
                .HasMaxLength(500)
                .IsRequired(false);

            #endregion

            #region Status

            // Status configuration
            builder
                .Property(check => check.Status)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #endregion

            #region Relationships

            // CustomerBankCheck -> Deposit
            // Every customer bank check must belong to exactly one deposit.
            builder
                .HasOne(check => check.Deposit)
                .WithOne(deposit => deposit.Check)
                .HasForeignKey<CustomerBankCheck>()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}