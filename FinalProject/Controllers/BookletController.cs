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

        //[HttpGet("{name}")]

        //public BookletDto Get(string name)
        //{
        //    return _bookletStore.GetBookletByName(name);
        //}

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
       
        


    }
}
