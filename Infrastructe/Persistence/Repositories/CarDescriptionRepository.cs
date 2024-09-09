namespace Persistence.Repositories;

public class CarDescriptionRepository : Repository<CarDescription>, ICarDescriptionRepository
{
    private readonly DatabaseContext _context;

    public CarDescriptionRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
