namespace Application.DTOs.CarFeatureDtos;

public class UpdateCarFeatureDto : IBaseDto
{
    public int Id { get; set; }
    public bool Available { get; set; }
    public int CarId { get; set; }
    public int FeatureId { get; set; }
}
