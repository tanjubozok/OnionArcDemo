namespace Application.Features.Mediator.Queries.PriceQueries;

public class GetPriceQuery : IRequest<List<GetPriceQueryResult>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
