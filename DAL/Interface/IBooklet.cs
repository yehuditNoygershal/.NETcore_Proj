using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Dtos;
using MODELS.Models;

namespace DAL.Interface
{
    public interface IBooklet
    {
       public Task<bool> CreateBooklet(BookletDto booklet);
       public List<Booklet> GetAllBooklets();
       public Booklet GetBookletByName(string name);
       public Task<bool> UpdatePrice(double price,int id);
       //public void DeleteBooklet(BookletDto booklet);
    }
}
