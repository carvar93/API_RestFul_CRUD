using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_RestFul_CRUD.Context;
using API_RestFul_CRUD.Entities;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_RestFul_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly AppDbContext _context;


        public ProductoController(AppDbContext context)
        {
            this._context = context;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _context.Producto.ToList();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            var producto = _context.Producto.FirstOrDefault(p=>p.pro_codigo==id);
            return producto;
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return Ok();
            }
            catch (ArgumentException e)
            {

                return BadRequest(e.Message);
            }
           
        
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Producto producto)
        {
            if (producto.pro_codigo == id)
            {
                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string  id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.pro_codigo == id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();

        }
    }
}
