namespace Application.DTOs.CarPriceDtos;

public class CreateCarPriceDto : IBaseDto
{
    public decimal Amount { get; set; }
    public int PriceId { get; set; }
    public int CarId { get; set; }
}
