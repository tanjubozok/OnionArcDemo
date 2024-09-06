﻿namespace Application.Features.Mediator.Queries.LocationQueries;

public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
{
    public int Id { get; set; }
    public GetLocationByIdQuery(int id)
    {
        Id = id;
    }
}
