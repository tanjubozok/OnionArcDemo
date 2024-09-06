namespace Application.Features.Mediator.Queries.FooterAddressQueries;

public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
{
    public int Id { get; set; }

    public GetFooterAddressByIdQuery(int id)
    {
        Id = id;
    }
}
