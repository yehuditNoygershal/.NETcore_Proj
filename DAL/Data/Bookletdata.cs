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

        public List<Booklet> GetAllBooklets()
        {
            return _context.Booklets.ToList();
        }

        public Booklet GetBookletByName(string name)
        {
            var mybooklet = _context.Booklets.FirstOrDefault(x => x.name == name);
            return mybooklet;
        }

        public async Task<bool> UpdatePrice(double price, int id)
        {
            var Booklet = await _context.Booklets
                                 .Where(x => x.Id ==id).FirstOrDefaultAsync();
            if (Booklet == null)
                return false;
            Booklet.price = price;
            await _context.SaveChangesAsync();
            return true;
        }

        //public void DeleteBooklet(BookletDto booklet)
        //{
        //    var myBooklet = _context.Booklets.Where(b => b.Id == booklet.Id);
        //    if (myBooklet != null)
        //    {
        //        _context.Booklets.Remove((Booklet)myBooklet);
        //        _context.SaveChanges();
        //    }
        //}




    }

}
