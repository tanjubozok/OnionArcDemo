namespace OnionArc.Domain.Entities;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<CarFeature>? CarFeatures { get; set; }
}