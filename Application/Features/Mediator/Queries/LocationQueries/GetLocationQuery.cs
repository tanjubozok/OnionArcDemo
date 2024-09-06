namespace Application.Features.Mediator.Queries.LocationQueries;

public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
