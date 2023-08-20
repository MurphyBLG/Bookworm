using Bookworm.Domain.OrderAggregate.Ids;
using Bookworm.Domain.Primitives;
using Bookworm.Domain.ProductAggregate.Ids;

namespace Bookworm.Domain.OrderAggregate.Entities;

public sealed class OrderItem : Entity<OrderItemId>
{
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public int Amount { get; private set; }

    private OrderItem(
        OrderItemId id,
        OrderId orderId,
        ProductId productId) 
        : base(id)
    {
        OrderId = orderId;
        ProductId = productId;
        Amount = 1;
    }

    public static OrderItem Create(OrderId orderId, ProductId productId)
        => new(new OrderItemId(Guid.NewGuid()), orderId, productId);

    public void AddItem()
    {
        Amount++;
    }
}
