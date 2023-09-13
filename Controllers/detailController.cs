using imageupload.Data;
using imageupload.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imageupload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class detailController : ControllerBase
    {
        private readonly Applicationdbcontext _context;
        public detailController(Applicationdbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get() 
        {
           var detail= _context.images.ToList();
            return Ok(detail);
        }
        [HttpPost]
        public IActionResult post([FromBody]Image image)
        {
            _context.images.Add(image);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var detail = _context.images.Find(id);
            if (detail == null)
            {
                return NotFound("detail not found");
            }
            return Ok(detail);
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            var detail = _context.images.Find(id);
            if (detail == null)
            {
                return NotFound("id not found");
            }
            _context.images.Remove(detail);
            _context.SaveChanges();
            return Ok("data delete");
        }
        [HttpPut]
        public IActionResult put([FromBody]Image image)
        { 
            _context.images.Update(image);
         _context.SaveChanges();
            return Ok("update");
        }
    }
}
