namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly CreateBrandCommandHandler _createBrandCommandHandler;
    private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
    private readonly DeleteBrandCommandHandler _deleteBrandCommandHandler;
    private readonly GetBrandQueryHandler _getBrandQueryHandler;
    private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

    public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, DeleteBrandCommandHandler deleteBrandCommandHandler, GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler)
    {
        _createBrandCommandHandler = createBrandCommandHandler;
        _updateBrandCommandHandler = updateBrandCommandHandler;
        _deleteBrandCommandHandler = deleteBrandCommandHandler;
        _getBrandQueryHandler = getBrandQueryHandler;
        _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getBrandQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        await _createBrandCommandHandler.Handle(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBrandCommand command)
    {
        try
        {
            await _updateBrandCommandHandler.Handle(command);
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
            await _deleteBrandCommandHandler.Handle(new DeleteBrandCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
