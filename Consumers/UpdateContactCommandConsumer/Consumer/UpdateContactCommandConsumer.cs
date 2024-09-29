using Application.Contracts;
using Application.Mediator.Command;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace Consumer
{
    public class UpdateContactCommandConsumer(IContactService contactService) : IConsumer<UpdateContactCommand>
    {
        private readonly IContactService _contactService = contactService;

        public async Task Consume(ConsumeContext<UpdateContactCommand> context)
        {
            await _contactService.Update(context.Message!);

        }
    }
}
