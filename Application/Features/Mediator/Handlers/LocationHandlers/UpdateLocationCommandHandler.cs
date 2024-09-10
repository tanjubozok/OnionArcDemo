namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.LocationRepository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        _unitOfWork.LocationRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
