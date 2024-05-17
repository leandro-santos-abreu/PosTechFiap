using Application.Contracts;
using Application.Mediator.Command;
using Application.Mediator.Queries;
using Domain.Models;
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
        var command = new UpdateContactCommand(contact.Id, contact.Name, contact.DDD, contact.Telephone, contact.Email);
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteContactCommand(id);
        var result = await _mediator.Send(command);
        return result ? Ok() : BadRequest();
    }
}