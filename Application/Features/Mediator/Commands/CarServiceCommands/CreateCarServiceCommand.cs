namespace Application.Features.Mediator.Commands.CarServiceCommands;

public class CreateCarServiceCommand : IRequest<IResponse<CreateCarServiceDto>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
