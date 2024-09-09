namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler
{
    private readonly IContactRepository _repository;

    public GetContactQueryHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetContactQueryResult
        {
            Email = x.Email,
            Id = x.Id,
            Message = x.Message,
            Name = x.Name,
            SendDate = x.SendDate,
            Subject = x.Subject
        }).ToList();
    }
}