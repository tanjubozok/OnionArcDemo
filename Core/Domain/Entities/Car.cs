namespace Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string BigImageUrl { get; set; } = string.Empty;
    public int KM { get; set; }
    public string Transmission { get; set; } = string.Empty;
    public byte Seat { get; set; }
    public byte Luggage { get; set; }
    public string Fuel { get; set; } = string.Empty;

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

    public List<CarFeature>? CarFeatures { get; set; }
    public List<CarDescription>? CarDescriptions { get; set; }
    public List<CarPrice>? CarPrices { get; set; }
}