namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class UpdateBrandCommandHandler
{
    private readonly IBrandRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandCommandHandler(IBrandRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBrandCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Brand with ID '{command.Id}' was not found.");

        value.Name = command.Name;

        _repository.Update(value);
    }
}
