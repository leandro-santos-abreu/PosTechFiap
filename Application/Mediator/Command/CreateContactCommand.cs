namespace Application.Mediator.Command;
public record CreateContactCommand(string Name, int DDD, string Telephone, string Email) : IRequest<bool>;
public class CreateContactCommandHandler(IContactService contactService) : IRequestHandler<CreateContactCommand, bool>
{
    public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        if (await contactService.Exists(request.DDD, request.Telephone)) return false;
        var result = await contactService.Create(request);
        return result;
    }
}