namespace Application.Features.Mediator.Commands.CarServiceCommands;

public class DeleteCarServiceCommand : IRequest<IResponse<DeleteCarServiceDto>>
{
    public int Id { get; set; }

    public DeleteCarServiceCommand(int id)
    {
        Id = id;
    }
}
