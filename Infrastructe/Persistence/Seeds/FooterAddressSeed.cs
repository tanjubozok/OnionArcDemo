namespace Persistence.Seeds;

public class FooterAddressSeed : IEntityTypeConfiguration<FooterAddress>
{
    public void Configure(EntityTypeBuilder<FooterAddress> builder)
    {
        var faker = new Faker<FooterAddress>()
            .RuleFor(fa => fa.Id, f => 1)
            .RuleFor(fa => fa.Description, f => f.Lorem.Sentence())
            .RuleFor(fa => fa.Address, f => f.Address.FullAddress())
            .RuleFor(fa => fa.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(fa => fa.Email, f => f.Internet.Email());

        var fakeData = faker.Generate(1);

        builder.HasData(fakeData);
    }
}