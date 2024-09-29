namespace Application.Contracts
{
    public interface IContactService 
    {
        Task<bool> Create(CreateContactCommand request);
        Task<IEnumerable<Contact>> Get(int? DDD);
        Task<bool> Update(UpdateContactCommand request);
        Task<bool> Exists(int DDD, string Telephone);
        Task<bool> ExistsById(int id);
        Task<bool> Delete(int id);
    }
}
