﻿namespace Domain.Entities;

public class CarFeature : IBaseEntity
{
    public int Id { get; set; }
    public bool Available { get; set; } = false;

    public int CarId { get; set; }
    public Car? Car { get; set; }

    public int FeatureId { get; set; }
    public Feature? Feature { get; set; }
}