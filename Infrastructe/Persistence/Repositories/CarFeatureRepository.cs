namespace Persistence.Repositories;

public class CarFeatureRepository : Repository<CarFeature>, ICarFeatureRepository
{
    public CarFeatureRepository(DatabaseContext context)
        : base(context)
    {
    }
}
