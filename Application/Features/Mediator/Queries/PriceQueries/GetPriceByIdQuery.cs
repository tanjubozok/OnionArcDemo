namespace Application.Features.Mediator.Queries.PriceQueries;

public class GetPriceByIdQuery : IRequest<GetPriceByIdQueryResult>
{
    public int Id { get; set; }

    public GetPriceByIdQuery(int id)
    {
        Id = id;
    }
}
