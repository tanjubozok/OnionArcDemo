namespace Application.Abstract;

public interface ICarRepository
{
    Task<List<Car>> GetCarWithBrandListAsync();
}
