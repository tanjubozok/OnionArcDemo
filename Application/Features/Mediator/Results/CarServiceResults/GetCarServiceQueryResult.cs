namespace Application.Features.Mediator.Results.CarServiceResults;

public class GetCarServiceQueryResult : IRequest<List<ListCarServiceDto>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
