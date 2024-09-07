namespace Persistence.Repositories;

public class CarServiceRepository : Repository<CarService>, ICarServiceRepository
{
    private readonly DatabaseContext _context;

    public CarServiceRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
