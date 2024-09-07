namespace Application.Features.Mediator.Queries.TestimonialQueries;

public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
{
    public int Id { get; set; }

    public GetTestimonialByIdQuery(int id)
    {
        Id = id;
    }
}
