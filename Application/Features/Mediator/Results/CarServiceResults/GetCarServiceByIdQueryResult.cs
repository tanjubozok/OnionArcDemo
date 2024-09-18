namespace Application.Features.Mediator.Results.CarServiceResults;

public class GetCarServiceByIdQueryResult : IRequest<GetByIdCarServiceDto>
{
    public int Id { get; set; }

    public GetCarServiceByIdQueryResult(int id)
    {
        Id = id;
    }
}
