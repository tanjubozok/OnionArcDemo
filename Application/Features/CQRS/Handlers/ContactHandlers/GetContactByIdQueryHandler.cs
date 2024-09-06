namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactByIdQueryHandler
{
    private readonly IRepository<Contact> _repository;

    public GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
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
