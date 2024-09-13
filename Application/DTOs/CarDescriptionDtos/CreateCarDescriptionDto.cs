namespace Application.DTOs.CarDescriptionDtos;

public class CreateCarDescriptionDto : IBaseDto
{
    public string Description { get; set; }
    public int CarId { get; set; }
}
