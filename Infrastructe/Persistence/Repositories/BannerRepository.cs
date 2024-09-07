namespace Persistence.Repositories;

public class BannerRepository : Repository<Banner>, IBannerRepository
{
    public BannerRepository(DatabaseContext context) 
        : base(context)
    {
    }
}
