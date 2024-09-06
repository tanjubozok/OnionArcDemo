namespace Application.Features.Mediator.Commands.CarServiceCommands;

public class DeleteCarServiceCommand:IRequest
{
    public int Id { get; set; }

    public DeleteCarServiceCommand(int id)
    {
        Id = id;
    }
}
