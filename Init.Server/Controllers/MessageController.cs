using Init.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Init.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    [HttpGet]
    public ActionResult<Message> GetMessage()
    {
        var message = new Message
        {
            Text = "Hello from the server!",
            Timestamp = DateTime.UtcNow
        };
        return Ok(message);
    }
}
