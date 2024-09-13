namespace Application.DTOs.FeatureDtos;

public class CreateFeatureDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
