namespace Persistence.Repositories;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    private readonly DatabaseContext _context;

    public ContactRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
