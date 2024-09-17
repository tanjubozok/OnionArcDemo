namespace Persistence.Seeds;

public class CarFeatureSeed : IEntityTypeConfiguration<CarFeature>
{
    public void Configure(EntityTypeBuilder<CarFeature> builder)
    {
        var carFeatureFaker = new Faker<CarFeature>()
           .RuleFor(cf => cf.Id, f => f.IndexFaker + 1)
           .RuleFor(cf => cf.Available, f => f.Random.Bool())
           .RuleFor(cf => cf.CarId, f => f.Random.Number(1, 10))
           .RuleFor(cf => cf.FeatureId, f => f.Random.Number(1, 10));

        var fakeData = carFeatureFaker.Generate(10);

        builder.HasData(fakeData);
    }
}
