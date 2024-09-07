namespace Domain.Entities;

public class Category : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}