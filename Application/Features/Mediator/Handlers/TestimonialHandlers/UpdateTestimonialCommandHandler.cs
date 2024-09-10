namespace Application.Features.Mediator.Handlers.TestimonialHandlers;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTestimonialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.TestimonialRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Testimonial with ID '{request.Id}' was not found.");

        value.Comment = request.Comment;
        value.Name = request.Name;
        value.ImageUrl = request.ImageUrl;
        value.Title = request.Title;

        _unitOfWork.TestimonialRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
