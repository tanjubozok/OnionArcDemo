namespace Application.Features.Mediator.Queries.CarServiceQueries;

public class GetCarServiceQuery : IRequest<List<GetCarServiceQueryResult>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}
