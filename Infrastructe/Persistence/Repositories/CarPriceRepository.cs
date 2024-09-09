namespace Persistence.Repositories;

public class CarPriceRepository : Repository<CarPrice>, ICarPriceRepository
{
    private readonly DatabaseContext _context;

    public CarPriceRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
