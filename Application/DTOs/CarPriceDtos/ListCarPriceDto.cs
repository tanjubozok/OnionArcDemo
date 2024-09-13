namespace Application.DTOs.CarPriceDtos;

public class ListCarPriceDto : IBaseDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int PriceId { get; set; }
    public int CarId { get; set; }
}
