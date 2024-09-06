﻿namespace Application.Features.Mediator.Queries.FooterAddressQueries;

public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
