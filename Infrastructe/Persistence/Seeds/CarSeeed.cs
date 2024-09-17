namespace Persistence.Seeds;

public class CarSeeed : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        var carFaker = new Faker<Car>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Model, f => f.Vehicle.Model())
            .RuleFor(c => c.CoverImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(c => c.BigImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(c => c.KM, f => f.Random.Int(0, 200000))
            .RuleFor(c => c.Transmission, f => f.PickRandom(new[] { "Manual", "Automatic" }))
            .RuleFor(c => c.Seat, f => f.Random.Byte(2, 7))
            .RuleFor(c => c.Luggage, f => f.Random.Byte(1, 5))
            .RuleFor(c => c.Fuel, f => f.PickRandom(new[] { "Gasoline", "Diesel", "Electric" }))
            .RuleFor(c => c.BrandId, f => f.Random.Int(1, 10));

        var fakeData = carFaker.Generate(10);

        builder.HasData(fakeData);
    }
}
