namespace Application.DTOs.TestimonialDtos;

public class ListTestimonialDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}
