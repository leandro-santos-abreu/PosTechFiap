using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contract
{
    public interface IContactRepository
    {
        Task<bool> Create(CreateContactRequest request);

    }
}
