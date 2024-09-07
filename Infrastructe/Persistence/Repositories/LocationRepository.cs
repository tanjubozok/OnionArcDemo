namespace Persistence.Repositories;

public class LocationRepository : Repository<Location>, ILocationRepository
{
    private readonly DatabaseContext _context;

    public LocationRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
