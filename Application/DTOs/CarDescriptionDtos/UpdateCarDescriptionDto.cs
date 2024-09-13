namespace Application.DTOs.CarDescriptionDtos;

public class UpdateCarDescriptionDto : IBaseDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int CarId { get; set; }
}
