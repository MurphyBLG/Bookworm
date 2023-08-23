using Bookworm.Domain.Common.ValueObjects;
using Bookworm.Domain.CustomerAggregate.Ids;
using Bookworm.Domain.OrderAggregate.Entities;
using Bookworm.Domain.OrderAggregate.Ids;
using Bookworm.Domain.Primitives;
using Bookworm.Domain.ProductAggregate;

namespace Bookworm.Domain.OrderAggregate;

public class Order : Entity<OrderId>
{
    private readonly HashSet<OrderItem> _orderItems = new();
    public CustomerId CustomerId { get; private set; }
    public Money Price { get; private set; }

    public void AddProductToOrder(Product product)
    {
        var productInOrder = _orderItems.FirstOrDefault(o => o.ProductId == product.Id);

        if (productInOrder is null)
        {
            _orderItems.Add(OrderItem.Create(Id, product.Id));
            return;
        }

        foreach (var item in _orderItems.Where(oi => oi.ProductId == product.Id))
            item.AddItem();
    }

    private Order(OrderId id, CustomerId customerId, Money price) : base(id)
    {
        Id = id;
        CustomerId = customerId;
        Price = price;
    }

    public static Order Create(CustomerId customerId, Money price)
        => new(new OrderId(Guid.NewGuid()), customerId, price);
}
