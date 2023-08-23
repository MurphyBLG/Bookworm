using Bookworm.Domain.Common.ValueObjects;
using Bookworm.Domain.Primitives;
using Bookworm.Domain.ProductAggregate.Ids;

namespace Bookworm.Domain.ProductAggregate;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Money Price { get; private set; } = null!;

    private Product(ProductId id, string name, string description, Money price) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public static Product Create(string name, string description, Money price)
        => new(new ProductId(Guid.NewGuid()), name, description, price);
}
