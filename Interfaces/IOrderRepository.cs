using KingstonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingstonAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDetail>> AllDetail();
        Task<IEnumerable<OrderDetail>> FindOrderDetail(string oid);
        Task<IEnumerable<OrderDetail>> FindOrderProduct(string pid);

        Task<IEnumerable<OrderList>> AllOrder();
        Task<IEnumerable<OrderList>> FindOrderID(string oid);
        Task<IEnumerable<OrderList>> FindOrderCustomer(string cid);

        Task InsertOrder(OrderList item);
        Task InsertDetail(OrderDetail item);

        Task UpdateOrder(OrderList item);
        Task UpdateDetail(OrderDetail item);

        Task DeleteOrder(string oid);
        Task DeleteDetail(string oid, string pid);
    }
}
