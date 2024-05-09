using Application.Contracts;
using Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace PosTechFiap.Controllers;

[Route("api/[controller]")]
public class ContactController(IContactService _contactService) : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] CreateContactRequest contact)
    {
        var result = await _contactService.Create(contact);

        return result ? Ok() : BadRequest();
    }
}