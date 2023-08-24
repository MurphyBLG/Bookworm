using Bookworm.Domain.OrderAggregate;
using Bookworm.Domain.OrderAggregate.Entities;
using Bookworm.Domain.OrderAggregate.Ids;
using Bookworm.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasConversion(orderItemId => orderItemId.Value,
                value => new OrderItemId(value));

        builder.HasOne<Order>()
            .WithMany()
            .HasForeignKey(o => o.OrderId);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(o => o.ProductId);

        builder.Property(o => o.Amount);
    }
}