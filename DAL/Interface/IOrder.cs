using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IOrder
    {
        public Task<bool> CreateOrder(OrderDto Order);
        public List<OrderDto> GetAllOrders();


    }
}
