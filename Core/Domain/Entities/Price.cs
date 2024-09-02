namespace Domain.Entities;

public class Price
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<CarPrice>? CarPrices { get; set; }
}