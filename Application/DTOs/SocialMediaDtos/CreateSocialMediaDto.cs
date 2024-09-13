namespace Application.DTOs.SocialMediaDtos;

public class CreateSocialMediaDto : IBaseDto
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
