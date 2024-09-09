namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly ILocationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(ILocationRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        value.Name = request.Name;

         _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
