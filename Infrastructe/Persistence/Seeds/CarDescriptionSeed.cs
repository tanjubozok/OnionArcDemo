namespace Persistence.Seeds;

public class CarDescriptionSeed : IEntityTypeConfiguration<CarDescription>
{
    public void Configure(EntityTypeBuilder<CarDescription> builder)
    {
        var faker = new Faker<CarDescription>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
            .RuleFor(b => b.CarId, f => f.Random.Int(1, 10));

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
