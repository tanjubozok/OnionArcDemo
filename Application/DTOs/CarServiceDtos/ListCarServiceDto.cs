namespace Application.DTOs.CarServiceDtos;

public class ListCarServiceDto : IBaseDto
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Description { get; set; }
    public string IconUrl { get; set; } 
}
