﻿namespace Domain.Entities;

public class Location : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}