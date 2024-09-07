namespace Persistence.Repositories;

public class FooterAddressRepository : Repository<FooterAddress>, IFooterAddressRepository
{
    private readonly DatabaseContext _context;

    public FooterAddressRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
