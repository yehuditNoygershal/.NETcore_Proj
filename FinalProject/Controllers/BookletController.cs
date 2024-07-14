using DAL.Dtos;
using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookletController : ControllerBase
    {
        private readonly IBooklet _bookletStore;

        public BookletController(IBooklet bookletStore)
        {
            _bookletStore = bookletStore;
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookletDto newBook)
        {
            var res = _bookletStore.CreateBooklet(newBook);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }

        [HttpGet]
        public List<BookletDto> Get()
        {
            List<BookletDto> result=_bookletStore.GetAllBooklets();
            return result;
            
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] double price)
        {
            _bookletStore.UpdatePrice(price, id);
            return Ok();

        }

        [HttpDelete("{id}")]
        public  ActionResult Delete(int id)
        {
            _bookletStore.DeleteBooklet(id);
            return Ok();

        }
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> UpdatePrice([FromBody] BookletDto bookletDto)
        //{
        //    var booklet = await _context.Booklets.FindAsync(bookletDto.Id);
        //    if (booklet == null)
        //    {
        //        return NotFound();
        //    }

        //    booklet.Price = bookletDto.Price;
        //    await _context.SaveChangesAsync();

        //    return Ok(); // Or CreatedAtAction("GetBooklet", new { id = bookletDto.Id }) if creating a new booklet
        //}

        //[HttpGet("{name}")]
        //public Booklet ActionResult Get(string name)
        //{
        //    return _bookletStore.GetBookletByName(name);
        //}


    }
}
