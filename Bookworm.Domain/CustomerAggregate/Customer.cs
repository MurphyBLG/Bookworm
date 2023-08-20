using Bookworm.Domain.CustomerAggregate.Ids;
using Bookworm.Domain.Primitives;

namespace Bookworm.Domain.CustomerAggregate;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public Customer(CustomerId id) : base(id)
    {
    }
}
