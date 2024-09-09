namespace Persistence.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    private readonly DatabaseContext _context;

    public BrandRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
