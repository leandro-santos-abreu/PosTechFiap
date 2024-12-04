using Application.Contracts;
using Application.Mediator.Command;
using MassTransit;

namespace Consumer
{
    public class CreateContactCommandConsumer(IContactService contactService) : IConsumer<CreateContactCommand>
    {
        private readonly IContactService _contactService = contactService;

        public async Task Consume(ConsumeContext<CreateContactCommand> context)
        {
            await _contactService.Create(context.Message!);

        }
    }
}
