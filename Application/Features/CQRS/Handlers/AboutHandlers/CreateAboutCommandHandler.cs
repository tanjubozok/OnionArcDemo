using Application.Results;

namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class CreateAboutCommandHandler
{
    private readonly IAboutRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAboutCommandHandler(IAboutRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<CreateAboutCommand>> Handle(CreateAboutCommand command)
    {
        await _repository.CreateAsync(new About
        {
            Description = command.Description,
            ImageUrl = command.ImageUrl,
            Title = command.Title
        });
        await _unitOfWork.SaveChangesAsync();

        return new Response<CreateAboutCommand>(ResponseType.Success, command, "Ekleme başarılı");
    }
}
