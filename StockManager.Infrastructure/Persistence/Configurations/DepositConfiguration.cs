using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.Infrastructure.Persistence.Configurations
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            #region Table Name

            // Table name
            builder.ToTable("Deposits");

            #endregion

            #region Properties

            #region Id

            // Primary key
            builder
                .HasKey(deposit => deposit.Id);

            // Id configuration
            builder
                .Property(deposit => deposit.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region AddingDate

            // AddingDate configuration
            builder
                .Property(deposit => deposit.AddingDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            #endregion

            #region Payment

            // Payment configuration
            builder
                .Property(deposit => deposit.Payment)
                .IsRequired()
                .HasConversion<int>();

            #endregion

            #region Amount

            // Amount configuration
            builder
                .Property(deposit => deposit.Amount)
                .HasPrecision(18, 2)
                .IsRequired(false);

            #endregion

            #region Note

            // Note configuration
            builder
                .Property(deposit => deposit.Note)
                .HasMaxLength(1000)
                .IsRequired(false);

            #endregion

            #endregion

            #region Relationships

            // Deposit -> Order
            // An order can have many deposits, but a deposit belongs to only one order.
            builder
                .HasOne(deposit => deposit.Order)
                .WithMany(order => order.Deposits)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Deposit -> CustomerBankCheck
            // Deposit may or may not have a customer bank check, but a customer bank check must belong to a deposit.
            builder
                .HasOne(deposit => deposit.Check)
                .WithOne(check => check.Deposit)
                .HasForeignKey<CustomerBankCheck>()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}