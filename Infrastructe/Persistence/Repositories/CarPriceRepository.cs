namespace Persistence.Repositories;

public class CarPriceRepository : Repository<CarPrice>, ICarPriceRepository
{
    public CarPriceRepository(DatabaseContext context)
        : base(context)
    {
    }
}
