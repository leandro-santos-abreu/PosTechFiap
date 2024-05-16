using Domain.Models;
using Domain.Request;

namespace Persistence.Contract
{
    public interface IContactRepository
    {
        Task<bool> Create(string Telephone, string Name, int DDD, string Email);
        Task<IEnumerable<Contact>> Get();
        Task<bool> Exists(int DDD, string Telephone);
        Task<bool> Update(UpdateContactRequest request);
        Task<bool> Delete(int id);
    }
}