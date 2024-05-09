using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IContactService 
    {
        Task<bool> Create(CreateContactRequest request);

    }
}
