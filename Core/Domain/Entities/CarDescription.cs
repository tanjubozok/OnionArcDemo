﻿namespace Domain.Entities;

public class CarDescription : IBaseEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public int CarId { get; set; }
    public Car? Car { get; set; }
}