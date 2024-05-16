using Application.Contracts;
using Application.Mediator.Command;
using Application.Mediator.Queries;
using Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PosTechFiap.Controllers;

[Route("api/[controller]")]
public class ContactController(IContactService _contactService, IMediator _mediator) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> Get(int? DDD) 
    {
        var query = new GetContactQuery(DDD);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] CreateContactRequest contact)
    {
        var command = new CreateContactCommand(contact.Name, contact.DDD, contact.Telephone, contact.Email);
        var result = await _mediator.Send(command);
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