using KingstonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingstonAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerList>> All();
        Task<IEnumerable<CustomerList>> FindID(string id);
        Task<IEnumerable<CustomerList>> FindCompanyName(string name);
        Task Insert(CustomerList item);
        Task Update(CustomerList item);
        Task Delete(string id);
    }
}
