namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class DeleteBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;

    public DeleteBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBrandCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Brand with ID '{command.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}