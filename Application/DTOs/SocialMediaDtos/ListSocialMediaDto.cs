namespace Application.DTOs.SocialMediaDtos;

public class ListSocialMediaDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
