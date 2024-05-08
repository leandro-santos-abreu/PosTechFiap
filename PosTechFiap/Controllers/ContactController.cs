using Microsoft.AspNetCore.Mvc;
using PosTechFiap.Request;

namespace PosTechFiap.Controllers;

[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    [HttpPost()]
    public IActionResult Create([FromBody] ContactRequest contact)
    {
        return Ok();
    }
}
