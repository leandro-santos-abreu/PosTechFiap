using MassTransit;

namespace Application.Mediator.Command;
public record DeleteContactCommand(int Id) : IRequest<bool>;
public class DeleteContactCommandHandler(IContactService contactService, IBus _bus) : IRequestHandler<DeleteContactCommand, bool>
{
    public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = (await contactService.Get(null)).SingleOrDefault(i => i.Id == request.Id);
        if (contact is null) return false;
        try
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:DeleteContact"));

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