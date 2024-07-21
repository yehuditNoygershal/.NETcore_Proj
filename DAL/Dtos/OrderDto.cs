using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public DateTime dateOrder { get; set; }
    }
}
