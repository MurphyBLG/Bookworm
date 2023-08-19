using Bookworm.Domain.Common.Enums;
using Bookworm.Domain.Primitives;

namespace Bookworm.Domain.Common;

public class Money : ValueObject
{
    public decimal Value { get; set; }
    public Currency Currency { get; set; }

    private Money(decimal value, Currency currencyCode)
    {
        Value = value;
        Currency = currencyCode;
    }

    public static Money Create(decimal value, Currency currencyCode)
        => new(value, currencyCode);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }
}
