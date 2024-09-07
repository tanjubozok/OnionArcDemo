namespace Persistence.Repositories;

public class TestimonialRepository : Repository<Testimonial>, ITestimonialRepository
{
    private readonly DatabaseContext _context;

    public TestimonialRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
