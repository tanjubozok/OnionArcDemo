namespace Domain.Entities;

public class Feature : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<CarFeature>? CarFeatures { get; set; }
}