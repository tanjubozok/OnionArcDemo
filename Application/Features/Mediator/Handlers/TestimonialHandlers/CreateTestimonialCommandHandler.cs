namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTestimonialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.TestimonialRepository.CreateAsync(new Testimonial
        {
            Comment = request.Comment,
            ImageUrl = request.ImageUrl,
            Name = request.Name,
            Title = request.Title
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
