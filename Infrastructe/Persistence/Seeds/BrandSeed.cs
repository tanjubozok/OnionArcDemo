namespace Persistence.Seeds;

public class BrandSeed : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        var faker = new Faker<Brand>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Name, f => f.Company.CompanyName());

        var fakeData = faker.Generate(20);

        builder.HasData(fakeData);
    }
}
