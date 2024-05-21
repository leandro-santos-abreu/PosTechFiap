using Application.Mediator.Command;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IContactService 
    {
        Task<bool> Create(CreateContactCommand request);
        Task<IEnumerable<Contact>> Get();
        Task<IEnumerable<Contact>> Get(int? DDD);
        Task<bool> Update(UpdateContactCommand request);
        Task<bool> Exists(int DDD, string Telephone);
        Task<bool> Delete(int id);
    }
}
