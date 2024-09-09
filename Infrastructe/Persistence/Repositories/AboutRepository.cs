namespace Persistence.Repositories;

public class AboutRepository : Repository<About>, IAboutRepository
{
    private readonly DatabaseContext _context;

    public AboutRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
