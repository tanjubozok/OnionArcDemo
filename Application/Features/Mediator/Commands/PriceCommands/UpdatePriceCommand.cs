namespace Application.Features.Mediator.Commands.PriceCommands;

public class UpdatePriceCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
