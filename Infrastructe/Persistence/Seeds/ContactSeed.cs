namespace Persistence.Seeds;

public class ContactSeed : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        var faker = new Faker<Contact>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Name, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Subject, f => f.Lorem.Sentence())
            .RuleFor(c => c.Message, f => f.Lorem.Paragraph())
            .RuleFor(c => c.SendDate, f => f.Date.Recent(30));

        var fakeData = faker.Generate(10);

        builder.HasData(fakeData);
    }
}
