using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordering.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerId).IsRequired();

        builder.HasIndex(x => x.OrderName).IsUnique();

        builder.Property(x => x.OrderName).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.OrderId);

        builder.ComplexProperty(
            o => o.ShippingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(50).IsRequired();
            });

        builder.ComplexProperty(
            o => o.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(50).IsRequired();
            });

        builder.ComplexProperty(o => o.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(p => p.CardName).HasMaxLength(50).IsRequired();
            paymentBuilder.Property(p => p.CardNumber).HasMaxLength(24).IsRequired();
            paymentBuilder.Property(p => p.Expiration).HasMaxLength(10).IsRequired();
            paymentBuilder.Property(p => p.CVV).HasMaxLength(3).IsRequired();
            paymentBuilder.Property(p => p.PaymentMethod);

        });

    }
}
