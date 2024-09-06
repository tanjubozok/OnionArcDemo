namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly GetContactQueryHandler _getContactQueryResultHandler;
    private readonly GetContactByIdQueryHandler _getContactByIdQueryResultHandler;
    private readonly UpdateContactCommandHandler _updateContactCommandHandler;
    private readonly DeleteContactCommandHandler _deleteContactCommandHandler;
    private readonly CreateContactCommandHandler _createContactCommandHandler;

    public ContactsController(GetContactQueryHandler getContactQueryResultHandler, GetContactByIdQueryHandler getContactByIdQueryResultHandler, UpdateContactCommandHandler updateContactCommandHandler, DeleteContactCommandHandler deleteContactCommandHandler, CreateContactCommandHandler createContactCommandHandler)
    {
        _getContactQueryResultHandler = getContactQueryResultHandler;
        _getContactByIdQueryResultHandler = getContactByIdQueryResultHandler;
        _updateContactCommandHandler = updateContactCommandHandler;
        _deleteContactCommandHandler = deleteContactCommandHandler;
        _createContactCommandHandler = createContactCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getContactQueryResultHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _getContactByIdQueryResultHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateContactCommand command)
    {
        await _createContactCommandHandler.Handle(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateContactCommand command)
    {
        try
        {
            await _updateContactCommandHandler.Handle(command);
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
            await _deleteContactCommandHandler.Handle(new DeleteContactCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
