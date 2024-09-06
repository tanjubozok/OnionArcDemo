namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand>
{
    private readonly IRepository<Price> _repository;

    public DeletePriceCommandHandler(IRepository<Price> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeletePriceCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Price with ID '{request.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
