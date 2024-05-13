using Application.Contracts;
using Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace PosTechFiap.Controllers;

[Route("api/[controller]")]
public class ContactController(IContactService _contactService) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> Get(int? DDD) => Ok(await _contactService.Get(DDD));

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] CreateContactRequest contact)
    {
        if(await _contactService.Exists(contact.DDD, contact.Email)) return BadRequest("Contact already exists.");
        var result = await _contactService.Create(contact);
        return result ? Ok() : BadRequest();
    }

    [HttpPut()]
    public async Task<IActionResult> Update([FromBody] UpdateContactRequest contact)
    {
        if(await _contactService.Exists(contact.DDD, contact.Telephone)) return BadRequest("Contact already exist.");
        var result = await _contactService.Update(contact);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(int id)
    {
        var contact = (await _contactService.Get()).SingleOrDefault(i => i.Id == id);
        if(contact is null) return BadRequest("Contact not found.");
        var result = await _contactService.Delete(id);
        return result ? Ok() : BadRequest();
    }
}