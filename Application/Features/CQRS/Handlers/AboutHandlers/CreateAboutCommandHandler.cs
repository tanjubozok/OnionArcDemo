namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class CreateAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAboutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<CreateAboutCommand>> Handle(CreateAboutCommand command)
    {
        try
        {
            await _unitOfWork.AboutRepository.CreateAsync(new About
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