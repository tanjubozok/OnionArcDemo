namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly IRepository<Price> _repository;

    public CreatePriceCommandHandler(IRepository<Price> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Price
        {
            Name = request.Name,
        });
    }
}
