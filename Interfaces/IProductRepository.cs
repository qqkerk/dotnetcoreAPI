using KingstonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingstonAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductList>> All();
        Task<IEnumerable<ProductList>> FindID(string id);
        Task<IEnumerable<ProductList>> FindName(string name);
        Task Insert(ProductList item);
        Task Update(ProductList item);
        Task Delete(string id);
    }
}
