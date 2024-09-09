namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly ITestimonialRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTestimonialCommandHandler(ITestimonialRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Testimonial with ID '{request.Id}' was not found.");

        value.Comment = request.Comment;
        value.Name = request.Name;
        value.ImageUrl = request.ImageUrl;
        value.Title = request.Title;

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
