namespace Persistence.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    private readonly DatabaseContext _context;

    public CarRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCarWithBrandListAsync()
    {
        return await _context.Cars
            .Include(x => x.Brand)
            .AsNoTracking()
            .ToListAsync();
    }
}