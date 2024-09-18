namespace Application.Abstract;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
