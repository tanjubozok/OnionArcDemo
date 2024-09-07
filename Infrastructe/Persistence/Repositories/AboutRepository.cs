namespace Persistence.Repositories;

public class AboutRepository : Repository<About>, IAboutRepository
{
    public AboutRepository(DatabaseContext context)
        : base(context)
    {
    }
}
