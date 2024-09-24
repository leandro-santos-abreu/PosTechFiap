using MassTransit;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Application.Mediator.Command;
public record CreateContactCommand(string Name, int DDD, string Telephone, string Email) : IRequest<bool>;
public class CreateContactCommandHandler(IContactService _contactService, IBus _bus) : IRequestHandler<CreateContactCommand, bool>
{
    public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        if (await _contactService.Exists(request.DDD, request.Telephone)) return false;

        try
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:CreateContact"));

            await endpoint.Send(request, cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
}