namespace Persistence.Contract
{
    public interface IContactRepository
    {
        Task<bool> Create(string Telephone, string Name, int DDD, string Email);
        Task<IEnumerable<Contact>> Get();
        Task<bool> Exists(int DDD, string Telephone);
        Task<bool> ExistsById(int id);
        Task<bool> Update(int Id, string Telephone, string Name, int DDD, string Email);
        Task<bool> Delete(int id);
    }
}