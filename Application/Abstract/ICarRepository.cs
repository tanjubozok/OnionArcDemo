namespace Application.Abstract;

public interface ICarRepository : IRepository<Car>
{
    Task<List<Car>> GetCarWithBrandListAsync();
}
