namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTestimonialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var values = await _unitOfWork.TestimonialRepository.GetAllAsync();
        return values.Select(x => new GetTestimonialQueryResult
        {
            Comment = x.Comment,
            Id = x.Id,
            ImageUrl = x.ImageUrl,
            Name = x.Name,
            Title = x.Title
        }).ToList();
    }
}
