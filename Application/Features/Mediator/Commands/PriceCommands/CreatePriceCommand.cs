﻿namespace Application.Features.Mediator.Commands.PriceCommands;

public class CreatePriceCommand : IRequest
{
    public string Name { get; set; }
}
