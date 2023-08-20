using Bookworm.Domain.Common.ValueObjects;
using Bookworm.Domain.Primitives;
using Bookworm.Domain.ProductAggregate.Ids;

namespace Bookworm.Domain.ProductAggregate;

public class Product : Entity<ProductId>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Money Price { get; private set; } = null!;

    public Product(ProductId id) : base(id)
    {
    }
}
