namespace Persistence.Seeds;

public class AboutSeed : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        var faker = new Faker<About>()
            .RuleFor(m => m.Id, f => f.IndexFaker + 1)
            .RuleFor(m => m.Title, f => f.Lorem.Sentence(3))
            .RuleFor(m => m.Description, f => f.Lorem.Paragraph())
            .RuleFor(m => m.ImageUrl, f => f.Image.PicsumUrl());

        List<About> fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}