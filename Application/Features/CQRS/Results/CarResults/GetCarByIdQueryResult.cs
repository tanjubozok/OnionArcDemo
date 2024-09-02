﻿namespace Application.Features.CQRS.Results.CarResults;

public class GetCarByIdQueryResult
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public string BigImageUrl { get; set; }
    public int KM { get; set; }
    public string Transmission { get; set; }
    public byte Seat { get; set; }
    public byte Luggage { get; set; }
    public string Fuel { get; set; }
    public int BrandId { get; set; }
}
