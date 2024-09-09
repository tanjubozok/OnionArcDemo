namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand>
{
    private readonly ITestimonialRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTestimonialCommandHandler(ITestimonialRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id) 
            ?? throw new KeyNotFoundException($"Testimonial with ID '{request.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
