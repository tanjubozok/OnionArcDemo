namespace Persistence.Seeds;

public class SocialMediaSeed : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        var faker = new Faker<SocialMedia>()
            .RuleFor(sm => sm.Id, f => 1) 
            .RuleFor(sm => sm.Name, f => f.Company.CompanyName()) 
            .RuleFor(sm => sm.Url, f => f.Internet.Url()) 
            .RuleFor(sm => sm.Icon, f => f.Image.PicsumUrl()); 

        var fakeData = faker.Generate(1);

        builder.HasData(fakeData);
    }
}
