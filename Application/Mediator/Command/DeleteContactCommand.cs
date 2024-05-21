namespace Application.Mediator.Command
{
    public record DeleteContactCommand(int Id) : IRequest<bool>;
    public class DeleteContactCommandHandler(IContactService contactService) : IRequestHandler<DeleteContactCommand, bool>
    {
        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = (await contactService.Get()).SingleOrDefault(i => i.Id == request.Id);
            if (contact is null) return false;
            var result = await contactService.Delete(request.Id);           
            return result;
        }
    }
}
