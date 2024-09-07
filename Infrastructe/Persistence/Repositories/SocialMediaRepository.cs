namespace Persistence.Repositories;

public class SocialMediaRepository : Repository<SocialMedia>, ISocialMediaRepository
{
    private readonly DatabaseContext _context;

    public SocialMediaRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
