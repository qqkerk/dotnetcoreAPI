using KingstonAPI.Interfaces;
using KingstonAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KingstonAPI.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KingstonTestContext _context;

        public OrderRepository(KingstonTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> AllDetail()
        {
            return await _context.OrderDetail.ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> FindOrderDetail(string oid)
        {
            return await _context.OrderDetail.Where(x => x.OId.Contains(oid)).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> FindOrderProduct(string pid)
        {
            return await _context.OrderDetail.Where(x => x.PId.Contains(pid)).ToListAsync();
        }

        public async Task<IEnumerable<OrderList>> AllOrder()
        {
            return await _context.OrderList.ToListAsync();
        }

        public async Task<IEnumerable<OrderList>> FindOrderID(string oid)
        {
            return await _context.OrderList.Where(x => x.OId.Contains(oid)).ToListAsync();
        }

        public async Task<IEnumerable<OrderList>> FindOrderCustomer(string cid)
        {
            return await _context.OrderList.Where(x => x.CId.Contains(cid)).ToListAsync();
        }

        public async Task InsertDetail(OrderDetail item)
        {
            await _context.OrderDetail.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task InsertOrder(OrderList item)
        {
            await _context.OrderList.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDetail(OrderDetail item)
        {
            var detailForUpdate = await _context.OrderDetail.Where(x => x.OId == item.OId)
                                        .Where(y => y.PId == item.PId).SingleOrDefaultAsync();

            if (detailForUpdate != null)
            {
                detailForUpdate.OrderNumber = item.OrderNumber;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(OrderList item)
        {
            var orderForUpdate = await _context.OrderList.SingleOrDefaultAsync(x => x.OId == item.OId);

            if (orderForUpdate != null)
            {
                orderForUpdate.CId = item.CId;
                orderForUpdate.Name = item.Name;
                orderForUpdate.OrderDate = item.OrderDate;
                orderForUpdate.DeliveryDate = orderForUpdate.DeliveryDate;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDetail(string oid, string pid)
        {
            var itemToRemove = await _context.OrderDetail.Where(x => x.OId == oid)
                                    .Where(y => y.PId ==pid).SingleOrDefaultAsync();
            if (itemToRemove != null)
            {
                _context.OrderDetail.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrder(string oid)
        {
            var itemToRemove = await _context.OrderList.SingleOrDefaultAsync(x => x.OId == oid);
            if (itemToRemove != null)
            {
                _context.OrderList.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
