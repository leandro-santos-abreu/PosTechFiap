using Domain.Models;
using Domain.Request;

namespace Persistence.Contract
{
    public interface IContactRepository
    {
        Task<bool> Create(CreateContactRequest request);
        Task<IEnumerable<Contact>> Get();
        Task<bool> Exists(int DDD, string Telephone);
        Task<bool> Update(UpdateContactRequest request);
        Task<bool> Delete(int id);
    }
}