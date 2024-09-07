namespace Persistence.Repositories;

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    private readonly DatabaseContext _context;

    public FeatureRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
