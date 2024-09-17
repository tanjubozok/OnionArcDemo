namespace Application.Features.Mediator.Commands.CarServiceCommands;

public class UpdateCarServiceCommand : IRequest<IResponse<UpdateCarServiceDto>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
