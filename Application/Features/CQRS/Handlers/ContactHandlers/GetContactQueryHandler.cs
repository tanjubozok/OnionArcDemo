namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values = await _unitOfWork.ContactRepository.GetAllAsync();
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