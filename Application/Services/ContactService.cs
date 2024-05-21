namespace Application.Services;
public class ContactService(IContactRepository contactRepository, IDDDRepository DDDRepository) : IContactService
{
    public async Task<bool> Create(CreateContactCommand request)
    {
        if (!await DDDRepository.Exist(request.DDD)) return false;
        return await contactRepository.Create(request.Telephone, request.Name, request.DDD, request.Email);
    }

    public async Task<IEnumerable<Contact>> Get(int? DDD)
    {
        var result = await contactRepository.Get();
        return DDD is null ? result : result.Where(x => x.DDD == DDD);
    }

    public async Task<bool> Exists(int DDD, string Telephone) => await contactRepository.Exists(DDD, Telephone);

    public async Task<bool> Update(UpdateContactCommand request)
    {
        if (!await DDDRepository.Exist(request.DDD)) return false;
        return await contactRepository.Update(request.Id,  request.Telephone, request.Name, request.DDD, request.Email);
    }

    public async Task<bool> Delete(int id) => await contactRepository.Delete(id);
}