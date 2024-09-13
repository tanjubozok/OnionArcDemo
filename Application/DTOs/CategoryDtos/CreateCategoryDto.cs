namespace Application.DTOs.CategoryDtos;

public class CreateCategoryDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
