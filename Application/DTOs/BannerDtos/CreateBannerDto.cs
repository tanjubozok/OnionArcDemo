namespace Application.DTOs.BannerDtos;

public class CreateBannerDto : IBaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoDescription { get; set; }
    public string VideoUrl { get; set; }
}
