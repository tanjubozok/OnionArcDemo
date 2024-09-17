namespace Persistence.Seeds;

public class CarPriceSeed : IEntityTypeConfiguration<CarPrice>
{
    public void Configure(EntityTypeBuilder<CarPrice> builder)
    {
        var faker = new Faker<CarPrice>()
            .RuleFor(cp => cp.Id, f => f.IndexFaker + 1)
            .RuleFor(cp => cp.Amount, f => f.Finance.Amount(10000, 50000))
            .RuleFor(cp => cp.PriceId, f => f.Random.Int(1, 10))
            .RuleFor(cp => cp.CarId, f => f.Random.Int(1, 10));

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
