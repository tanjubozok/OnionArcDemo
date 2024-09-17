namespace Persistence.Seeds;

public class CarServiceSeed : IEntityTypeConfiguration<CarService>
{
    public void Configure(EntityTypeBuilder<CarService> builder)
    {
        var faker = new Faker<CarService>()
            .RuleFor(cs => cs.Id, f => f.IndexFaker + 1)
            .RuleFor(cs => cs.Title, f => f.Commerce.ProductName())
            .RuleFor(cs => cs.Description, f => f.Lorem.Paragraph())
            .RuleFor(cs => cs.IconUrl, f => f.Image.PicsumUrl());

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
