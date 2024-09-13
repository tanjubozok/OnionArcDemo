namespace Application.DTOs.TestimonialDtos;

public class CreateTestimonialDto : IBaseDto
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}
