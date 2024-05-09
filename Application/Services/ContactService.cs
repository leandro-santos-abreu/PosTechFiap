using Application.Contracts;
using Domain.Request;
using Persistence.Contract;
using Persistence.Repositories;
using System.Text.RegularExpressions;

namespace Application.Services;
public class ContactService(IContactRepository _contactRepository) : IContactService
{
    public async Task<bool> Create(CreateContactRequest request)
    {
        if (request.Telephone.Length > 9) return false;

        if (!Regex.IsMatch(request.Name, @"[^a-zA-Z0-9\s]")) return false;

        //TODO: validar se o numero de telefone + DDD já foi inserido anteriormente.

        await _contactRepository.Create(request);

        return true;
    }

    public void UpdateContact()
    {
        // Update contact logic here
    }
    public void DeleteContact()
    {
        // Delete contact logic here
    }
    public void GetContact()
    {
        // Get contact logic here
    }
    public void GetContacts()
    {
        // Get contacts logic here
    }
}
