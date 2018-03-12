using KingstonAPI.Interfaces;
using KingstonAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingstonAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly KingstonTestContext _context;

        public ProductRepository(KingstonTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductList>> All()
        {
            return await _context.ProductList.ToListAsync(); 
        }

        public async Task<IEnumerable<ProductList>> FindID(string id)
        {
            return await _context.ProductList.Where(x => x.PId.Contains(id)).ToListAsync();
        }

        public async Task<IEnumerable<ProductList>> FindName(string name)
        {
            return await _context.ProductList.Where(x => x.PName.Contains(name)).ToListAsync();
        }

        public async Task Insert(ProductList item)
        {
            await _context.ProductList.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductList item)
        {
            var productForUpdate = await _context.ProductList.SingleOrDefaultAsync(x => x.PId == item.PId);

            if (productForUpdate != null)
            {
                productForUpdate.PName = item.PName;
                productForUpdate.PDescription = item.PDescription;
                productForUpdate.PPrice = item.PPrice;
     
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var itemToRemove = await _context.ProductList.SingleOrDefaultAsync(x => x.PId == id);
            if (itemToRemove != null)
            {
                _context.ProductList.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

    }
}
