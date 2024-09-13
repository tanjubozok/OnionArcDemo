namespace Application.DTOs.CarFeatureDtos;

public class CreateCarFeatureDto : IBaseDto
{
    public bool Available { get; set; }
    public int CarId { get; set; }
    public int FeatureId { get; set; }
}
