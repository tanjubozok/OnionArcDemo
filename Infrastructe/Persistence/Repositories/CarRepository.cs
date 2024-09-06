namespace Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DatabaseContext _context;

    public CarRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCarWithBrandListAsync()
    {
        var result = await _context.Cars.Include(x => x.Brand).ToListAsync();
        return result;
    }
}
