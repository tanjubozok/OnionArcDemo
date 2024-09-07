namespace Domain.Entities;

public class CarPrice : IBaseEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    public int PriceId { get; set; }
    public Price? Price { get; set; }

    public int CarId { get; set; }
    public Car? Car { get; set; }
}