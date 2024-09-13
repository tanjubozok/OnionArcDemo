namespace Application.DTOs.AboutDtos;

public class CreateAboutDto : IBaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
