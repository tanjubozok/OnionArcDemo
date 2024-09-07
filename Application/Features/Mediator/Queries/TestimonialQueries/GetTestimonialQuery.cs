namespace Application.Features.Mediator.Queries.TestimonialQueries;

public class GetTestimonialQuery:IRequest<List<GetTestimonialQueryResult>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}
