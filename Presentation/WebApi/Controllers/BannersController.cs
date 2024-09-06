namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BannersController : ControllerBase
{
    private readonly GetBannerQueryHandler _queryHandler;
    private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly DeleteBannerCommandHandler _deleteBannerCommandHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

    public BannersController(GetBannerQueryHandler queryHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, DeleteBannerCommandHandler deleteBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
    {
        _queryHandler = queryHandler;
        _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        _createBannerCommandHandler = createBannerCommandHandler;
        _deleteBannerCommandHandler = deleteBannerCommandHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _queryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBannerCommand command)
    {
        try
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _deleteBannerCommandHandler.Handle(new DeleteBannerCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
