namespace Persistence.Seeds;

public class LocationSeed : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        var faker = new Faker<Location>()
            .RuleFor(l => l.Id, f => 1)
            .RuleFor(l => l.Name, f => f.Address.City());

        var fakeData = faker.Generate(1);

        builder.HasData(fakeData);
    }
}
