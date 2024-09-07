namespace Persistence.Repositories;

public class CarDescriptionRepository : Repository<CarDescription>, ICarDescriptionRepository
{
    public CarDescriptionRepository(DatabaseContext context)
        : base(context)
    {
    }
}
