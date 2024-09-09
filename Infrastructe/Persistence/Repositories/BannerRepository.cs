namespace Persistence.Repositories;

public class BannerRepository : Repository<Banner>, IBannerRepository
{
    private readonly DatabaseContext _context;

    public BannerRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
