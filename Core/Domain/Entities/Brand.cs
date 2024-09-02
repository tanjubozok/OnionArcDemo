﻿namespace Domain.Entities;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Car>? Cars { get; set; }
}