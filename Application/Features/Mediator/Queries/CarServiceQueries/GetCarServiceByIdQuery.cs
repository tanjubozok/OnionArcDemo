namespace Application.Features.Mediator.Queries.CarServiceQueries;

public class GetCarServiceByIdQuery : IRequest<GetCarServiceByIdQueryResult>
{
    public int Id { get; set; }

    public GetCarServiceByIdQuery(int id)
    {
        Id = id;
    }
}
