namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
{
    private readonly ITestimonialRepository _repository;

    public GetTestimonialByIdQueryHandler(ITestimonialRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Testimonial with ID '{request.Id}' was not found.");
        
        return new GetTestimonialByIdQueryResult
        {
            Id = value.Id,
            Comment = value.Comment,
            ImageUrl = value.ImageUrl,
            Name = value.Name,
            Title = value.Title
        };
    }
}