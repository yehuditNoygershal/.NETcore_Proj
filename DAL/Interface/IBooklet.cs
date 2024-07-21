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
       public List<BookletDto> GetAllBooklets();
       //public BookletDto GetBookletByName(string name);
       public void UpdatePrice(double price,int id);
       public void DeleteBooklet(int id);
    }
}
