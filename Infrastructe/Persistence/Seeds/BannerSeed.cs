namespace Persistence.Seeds;

public class BannerSeed : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        var faker = new Faker<Banner>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
            .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
            .RuleFor(b => b.VideoDescription, f => f.Lorem.Sentence(5))
            .RuleFor(b => b.VideoUrl, f => f.Internet.Url());

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
