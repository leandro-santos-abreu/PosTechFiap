using Domain.Models;
using Domain.Request;

namespace Application.Contracts
{
    public interface IContactService 
    {
        Task<bool> Create(CreateContactRequest request);
        Task<IEnumerable<Contact>> Get();
        Task<IEnumerable<Contact>> Get(int? DDD);
        Task<bool> Exists(int DDD, string Telephone);
        Task<bool> Update(UpdateContactRequest request);
        Task<bool> Delete(int id);
    }
}
