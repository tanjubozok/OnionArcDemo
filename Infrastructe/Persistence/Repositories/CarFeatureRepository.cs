namespace Persistence.Repositories;

public class CarFeatureRepository : Repository<CarFeature>, ICarFeatureRepository
{
    private readonly DatabaseContext _context;

    public CarFeatureRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
