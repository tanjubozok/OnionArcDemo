namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class UpdateCarServiceCommandHandler : IRequestHandler<UpdateCarServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCarServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.CarServiceRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"CarService with ID '{request.Id}' was not found.");

        value.Description = request.Description;
        value.Title = request.Title;
        value.IconUrl = request.IconUrl;

        _unitOfWork.CarServiceRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
