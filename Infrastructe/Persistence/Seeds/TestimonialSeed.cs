namespace Persistence.Seeds;

public class TestimonialSeed : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        var faker = new Faker<Testimonial>()
            .RuleFor(t => t.Id, f => 1)
            .RuleFor(t => t.Name, f => f.Person.FullName)
            .RuleFor(t => t.Title, f => f.Lorem.Sentence(3)) 
            .RuleFor(t => t.Comment, f => f.Lorem.Paragraph()) 
            .RuleFor(t => t.ImageUrl, f => f.Image.PicsumUrl()); 

        var fakeData = faker.Generate(1);

        builder.HasData(fakeData);
    }
}
