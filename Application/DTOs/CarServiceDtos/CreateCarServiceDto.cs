namespace Application.DTOs.CarServiceDtos;

public class CreateCarServiceDto : IBaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
