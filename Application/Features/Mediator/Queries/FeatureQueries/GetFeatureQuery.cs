namespace Application.Features.Mediator.Queries.FeatureQueries;

public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
