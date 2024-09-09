namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
{
    private readonly ITestimonialRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTestimonialCommandHandler(ITestimonialRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Testimonial
        {
            Comment = request.Comment,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
            Title = request.Title
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
