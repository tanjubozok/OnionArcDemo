namespace Application.Features.Mediator.Commands.PriceCommands;

public class DeletePriceCommand : IRequest
{
    public int Id { get; set; }

    public DeletePriceCommand(int id)
    {
        Id = id;
    }
}
