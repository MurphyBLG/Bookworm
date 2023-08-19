using Bookworm.Domain.Customer.Ids;

namespace Bookworm.Domain.Customer;

public class Customer
{
    public CustomerId Id { get; private init; } = null!;
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
}
