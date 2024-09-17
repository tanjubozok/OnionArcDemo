namespace Persistence.Seeds;

public class PriceSeed : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        var priceFaker = new Faker<Price>()
            .RuleFor(p => p.Id, f => 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName());

        var fakeData = priceFaker.Generate(1);

        builder.HasData(fakeData);
    }
}
