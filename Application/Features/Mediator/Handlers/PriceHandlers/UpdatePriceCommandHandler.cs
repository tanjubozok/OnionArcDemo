namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand>
{
    private readonly IRepository<Price> _repository;

    public UpdatePriceCommandHandler(IRepository<Price> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
                   ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        await _repository.UpdateAsync(value);
    }
}
