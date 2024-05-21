using Application.Contracts;
using Application.Mediator.Command;
using Domain.Entities;
using Persistence.Contract;

namespace Application.Services;
public class ContactService(IContactRepository _contactRepository) : IContactService
{
    public async Task<bool> Create(CreateContactCommand request)
    {        
        return await _contactRepository.Create(request.Telephone, request.Name, request.DDD, request.Email);
    }

    public async Task<IEnumerable<Contact>> Get() => await _contactRepository.Get();

    public async Task<IEnumerable<Contact>> Get(int? DDD)
    {
        var result = await _contactRepository.Get();
        return DDD is null ? result : result.Where(x => x.DDD == DDD);
    }

    public async Task<bool> Exists(int DDD, string Telephone) => await _contactRepository.Exists(DDD, Telephone);

    public async Task<bool> Update(UpdateContactCommand request)
    {       
        return await _contactRepository.Update(request.Id,  request.Telephone, request.Name, request.DDD, request.Email);
    }

    public async Task<bool> Delete(int id) => await _contactRepository.Delete(id);
}
