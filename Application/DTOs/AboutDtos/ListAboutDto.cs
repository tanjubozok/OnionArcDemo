﻿namespace Application.DTOs.AboutDtos;

public class ListAboutDto : IBaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
