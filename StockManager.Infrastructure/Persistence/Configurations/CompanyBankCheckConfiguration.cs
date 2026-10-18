using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class CompanyBankCheckConfiguration : IEntityTypeConfiguration<CompanyBankCheck>
    {
        public void Configure(EntityTypeBuilder<CompanyBankCheck> builder)
        {
            #region Table Name

            // Configure the table name
            builder.ToTable("CompanyBankChecks");

            #endregion

            #region Properties

            #region Id

            // Configure the primary key
            builder.HasKey(check => check.Id);

            // Configure the primary key to be generated automatically
            builder.Property(check => check.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Owner

            // Configure the check owner's name
            builder.Property(check => check.Owner)
                .IsRequired()
                .HasMaxLength(200);

            #endregion

            #region BankName

            // Configure the bank name
            builder.Property(check => check.BankName)
                .IsRequired()
                .HasMaxLength(150);

            #endregion

            #region Amount

            // Configure the check amount
            builder.Property(check => check.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            #endregion

            #region Image

            // Configure the check image path or URL
            builder.Property(check => check.Image)
                .IsRequired(false)
                .HasMaxLength(500);

            #endregion

            #region DueDate

            // Configure the due date
            // Null-able because a due date may not always be recorded.
            builder.Property(check => check.DueDate)
                .IsRequired(false);

            #endregion

            #region Status

            // Configure the check status
            // Store the enum as an integer in the database.
            builder.Property(check => check.Status)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #endregion

            #region Relationship

            // CompanyBankCheck -> Supply (Many-to-One)
            // A supply can have multiple company bank checks, a company bank check must belong to exactly one supply.
            builder.HasOne(check => check.Supply)
                .WithMany(supply => supply.CompanyBankChecks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}