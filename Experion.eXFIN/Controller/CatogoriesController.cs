using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Experion.MyCart.Data.Entities;

namespace Experion.MyCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatogoriesController : ControllerBase
    {
        private readonly MyCartDBContext _context;

        public CatogoriesController(MyCartDBContext context)
        {
            _context = context;
        }

        // GET: api/Catogories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catogory>>> GetCatogory()
        {
            return await _context.Catogory.ToListAsync();
        }

        // PUT: api/Catogories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatogory(int id, Catogory catogory)
        {
            if (id != catogory.CatogoryId)
            {
                return BadRequest();
            }

            _context.Entry(catogory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatogoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Catogory>> PostCatogory(Catogory catogory)
        {
            _context.Catogory.Add(catogory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatogory", new { id = catogory.CatogoryId }, catogory);
        }

        // DELETE: api/Catogories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Catogory>> DeleteCatogory(int id)
        {
            var catogory = await _context.Catogory.FindAsync(id);
            if (catogory == null)
            {
                return NotFound();
            }

            _context.Catogory.Remove(catogory);
            await _context.SaveChangesAsync();

            return catogory;
        }

        private bool CatogoryExists(int id)
        {
            return _context.Catogory.Any(e => e.CatogoryId == id);
        }
    }
}
