namespace Persistence.Repositories;

public class PriceRepository : Repository<Price>, IPriceRepository
{
    private readonly DatabaseContext _context;

    public PriceRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
