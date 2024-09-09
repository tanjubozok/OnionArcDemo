namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactByIdQueryHandler
{
    private readonly IContactRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetContactByIdQueryHandler(IContactRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return value == null
            ? throw new KeyNotFoundException($"Contact with ID '{query.Id}' was not found.")
            : new GetContactByIdQueryResult
            {
                Email = value.Email,
                Id = value.Id,
                Message = value.Message,
                Name = value.Name,
                SendDate = value.SendDate,
                Subject = value.Subject,
            };
    }
}
