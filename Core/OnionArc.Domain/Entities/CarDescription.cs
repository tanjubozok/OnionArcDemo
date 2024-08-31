namespace OnionArc.Domain.Entities;

public class CarDescription
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public int CarId { get; set; }
    public Car? Car { get; set; }
}