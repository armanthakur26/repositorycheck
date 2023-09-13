using imageupload.Models;
using imageupload.Repository.Irepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace imageupload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {

        private readonly Iunitofwork _unitofwork;
        public BikesController(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var oko = _unitofwork.Bikes.GetAll();
            return Ok(oko);
        }
        [HttpPost]
        public IActionResult Add([FromBody] bikes bikes)
        {
            _unitofwork.Bikes.Add(bikes);
            return Ok();
        }
        [HttpDelete]
        public IActionResult del(int id)
        {
            _unitofwork.Bikes.remove(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult update([FromBody] bikes bikes)
        {
            _unitofwork.Bikes.Update(bikes);
            return Ok();
        }
        [HttpGet("{id:int}")]
        public IActionResult getbyid(int id)
        {
            var oko=_unitofwork.Bikes.get(id);
            return Ok(oko);
        }
    }
}
