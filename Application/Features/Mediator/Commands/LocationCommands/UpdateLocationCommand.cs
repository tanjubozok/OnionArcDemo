﻿namespace Application.Features.Mediator.Commands.LocationCommands;

public class UpdateLocationCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
