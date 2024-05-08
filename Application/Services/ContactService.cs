using Domain.Request;
using System.Text.RegularExpressions;

namespace Application.Services;
public class ContactService
{
    public bool Create(CreateContactRequest request)
    {
        if (request.Telephone.Length > 9) return false;

        if (!Regex.IsMatch(request.Name, @"[^a-zA-Z0-9\s]")) return false;

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
