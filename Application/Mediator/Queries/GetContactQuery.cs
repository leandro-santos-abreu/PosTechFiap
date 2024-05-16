using Application.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Mediator.Queries;
public record GetContactQuery(int? DDD) : IRequest<IEnumerable<Contact>>;

public class GetContactQueryHandler(IContactService contactService) : IRequestHandler<GetContactQuery, IEnumerable<Contact>>
{
    public async Task<IEnumerable<Contact>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        return await contactService.Get(request.DDD);
    }
}