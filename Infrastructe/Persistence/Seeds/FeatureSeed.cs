namespace Persistence.Seeds;

public class FeatureSeed : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        var faker = new Faker<Feature>()
            .RuleFor(f => f.Id, f => f.IndexFaker + 1)
            .RuleFor(f => f.Name, f => f.Commerce.ProductAdjective());

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
