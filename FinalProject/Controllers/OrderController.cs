using DAL.Dtos;
using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order=order;
        }

        [HttpPost]
        public ActionResult Post([FromBody] OrderDto neworder)
        {
            var res =_order.CreateOrder(neworder);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }

        [HttpGet]
        public List<OrderDto> Get()
        {
            List<OrderDto> result =_order.GetAllOrders();
            return result;
        }
    }
}
