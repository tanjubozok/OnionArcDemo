namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly DeleteCarCommandHandler _deleteCarCommandHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

    public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, DeleteCarCommandHandler deleteCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
    {
        _createCarCommandHandler = createCarCommandHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _deleteCarCommandHandler = deleteCarCommandHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _getCarQueryHandler = getCarQueryHandler;
        _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getCarQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCarCommand command)
    {
        try
        {
            await _updateCarCommandHandler.Handle(command);
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
            await _deleteCarCommandHandler.Handle(new DeleteCarCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetCarWithBrand")]
    public async Task<IActionResult> GetAllCarWithBrand()
    {
        try
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}