namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetCarServiceQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _mediator.Send(new GetCarServiceByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarServiceCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCarServiceCommand command)
    {
        try
        {
            await _mediator.Send(command);
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
            await _mediator.Send(new DeleteCarServiceCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
