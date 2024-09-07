namespace Persistence.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(DatabaseContext context)
        : base(context)
    {
    }
}
