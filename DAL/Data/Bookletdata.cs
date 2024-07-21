using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Dtos;
using DAL.Interface;
using MODELS.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class BookletData:IBooklet
    {
        private readonly BookletContext _context;
        private readonly IMapper _mapper;
        public BookletData(BookletContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateBooklet(BookletDto newbooklet)
        {
            var myBook = _mapper.Map<Booklet>(newbooklet);
            _context.Booklets.Add(myBook);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }

        public List<BookletDto> GetAllBooklets()
        {
           var mybooklets= _context.Booklets.ToList();
            var mybookletsDto =_mapper.Map <List<BookletDto>>(mybooklets);
            return mybookletsDto;
        }

        //public BookletDto GetBookletByName(string name)
        //{
        //    var booklet = _context.Booklets.Find(name);
        //    var bookletDto = _mapper.Map<BookletDto>(booklet);
        //    return bookletDto;
        //}


        public  void UpdatePrice(double price, int id)
        {
            var Booklet = _context.Booklets.Find(id);

            if (Booklet == null)
            {
                throw new NotImplementedException();
            }
               
            Booklet.price = price;

            _context.Update(Booklet);
             _context.SaveChangesAsync();   
        }


        public void DeleteBooklet(int id)
        {
            var booklet = _context.Booklets.Where(b => b.Id == id).FirstOrDefault();

            if (booklet != null)
            {
                _context.Booklets.Remove(booklet);
                _context.SaveChanges();
            }
        }





    }

}
