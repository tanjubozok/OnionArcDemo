namespace Application.DTOs.CategoryDtos;

public class UpdateCategoryDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
