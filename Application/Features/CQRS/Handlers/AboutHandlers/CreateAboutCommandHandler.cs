namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class CreateAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAboutRepository _aboutRepository;

    public CreateAboutCommandHandler(IUnitOfWork unitOfWork, IAboutRepository aboutRepository)
    {
        _unitOfWork = unitOfWork;
        _aboutRepository = aboutRepository;
    }

    public async Task<Response<CreateAboutCommand>> Handle(CreateAboutCommand command)
    {
        try
        {
            await _aboutRepository.CreateAsync(new About
            {
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                Title = command.Title
            });

            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0)
                return new Response<CreateAboutCommand>(ResponseType.Success, command, Message.Success);

            return new Response<CreateAboutCommand>(ResponseType.SaveError, Message.SaveError);
        }
        catch (Exception ex)
        {
            return new Response<CreateAboutCommand>(ResponseType.TryCatch, ex.Message);
        }
    }
}