using Bookworm.Domain.CustomerAggregate;
using Bookworm.Domain.CustomerAggregate.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Id)
            .HasConversion(customerId => customerId.Value,
                value => new CustomerId(value));

        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();
    }
}
