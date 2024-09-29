using MassTransit;

namespace Application.Mediator.Command;
public record UpdateContactCommand(int Id, string Name, int DDD, string Telephone, string Email) : IRequest<bool>;
public class UpdateContactCommandHandler(IContactService contactService, IBus _bus) : IRequestHandler<UpdateContactCommand, bool>
{
    public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        if (!await contactService.ExistsById(request.Id)) return false;

        try
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:UpdateContact"));

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
