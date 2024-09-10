namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTestimonialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.TestimonialRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Testimonial with ID '{request.Id}' was not found.");

        _unitOfWork.TestimonialRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
