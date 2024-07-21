using AutoMapper;
using DAL.Dtos;
using DAL.Interface;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Data
{
    public class Orderdata:IOrder
    {
        private readonly BookletContext _context;
        private readonly IMapper _mapper;
        public Orderdata(BookletContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateOrder(OrderDto neworder)
        {
            var myOrder = _mapper.Map<Orders>(neworder);
            _context.Orders.Add(myOrder);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }

        public List<OrderDto> GetAllOrders()
        {
            var myorders = _context.Orders.ToList();
            var myordersDto = _mapper.Map<List<OrderDto>>(myorders);
            return myordersDto;
        }

    }
}
