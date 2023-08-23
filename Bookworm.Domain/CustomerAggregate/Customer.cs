using Bookworm.Domain.CustomerAggregate.Ids;
using Bookworm.Domain.Primitives;

namespace Bookworm.Domain.CustomerAggregate;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    private Customer(CustomerId id, string name, string email) : base(id)
    {
        Name = name;
        Email = email;
    }

    public static Customer Create(string name, string email)
        => new(new CustomerId(Guid.NewGuid()), name, email);
}
