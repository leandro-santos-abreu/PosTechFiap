namespace Application.Mediator.Command;
public record UpdateContactCommand(int Id, string Name, int DDD, string Telephone, string Email) : IRequest<bool>;
public class UpdateContactCommandHandler(IContactService contactService) : IRequestHandler<UpdateContactCommand, bool>
{
    public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        if (!await contactService.Exists(request.DDD, request.Telephone)) return false;
        var result = await contactService.Update(request);
        return result;
    }
}
