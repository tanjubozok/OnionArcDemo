namespace Persistence.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var faker = new Faker<Category>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
