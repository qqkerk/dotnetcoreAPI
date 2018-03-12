using KingstonAPI.Interfaces;
using KingstonAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingstonAPI.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KingstonTestContext _context;

        public CustomerRepository(KingstonTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerList>> All()
        {
            return await _context.CustomerList.ToListAsync(); 
        }

        public async Task<IEnumerable<CustomerList>> FindID(string id)
        {
            return await _context.CustomerList.Where(x => x.CId.Contains(id)).ToListAsync();
        }

        public async Task<IEnumerable<CustomerList>> FindCompanyName(string name)
        {
            return await _context.CustomerList.Where(x => x.CCompanyName.Contains(name)).ToListAsync();
        }

        public async Task Insert(CustomerList item)
        {
            await _context.CustomerList.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CustomerList item)
        {
            var CustomerForUpdate = await _context.CustomerList.SingleOrDefaultAsync(x => x.CId == item.CId);

            if (CustomerForUpdate != null)
            {
                CustomerForUpdate.CCompanyName = item.CCompanyName;
                CustomerForUpdate.CAddress = item.CAddress;
                CustomerForUpdate.CContactName = item.CContactName;
                CustomerForUpdate.CPhone = item.CPhone;
                CustomerForUpdate.CEmail = item.CEmail;
                CustomerForUpdate.CFax = item.CFax;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var itemToRemove = await _context.CustomerList.SingleOrDefaultAsync(x => x.CId == id);
            if (itemToRemove != null)
            {
                _context.CustomerList.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

    }
}
