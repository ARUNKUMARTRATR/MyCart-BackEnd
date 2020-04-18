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
    public class ProductOrdersController : ControllerBase
    {
        private readonly MyCartDBContext _context;

        public ProductOrdersController(MyCartDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOrders>>> GetProductOrders()
        {
            return await _context.ProductOrders.ToListAsync();
        }

        // GET: api/ProductOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOrders>> GetProductOrders(int id)
        {
            var productOrders = await _context.ProductOrders.FindAsync(id);

            if (productOrders == null)
            {
                return NotFound();
            }

            return productOrders;
        }

        // PUT: api/ProductOrders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOrders(int id, ProductOrders productOrders)
        {
            if (id != productOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(productOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrdersExists(id))
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

        // POST: api/ProductOrders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductOrders>> PostProductOrders(ProductOrders productOrders)
        {
            _context.ProductOrders.Add(productOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductOrders", new { id = productOrders.Id }, productOrders);
        }

        // DELETE: api/ProductOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductOrders>> DeleteProductOrders(int id)
        {
            var productOrders = await _context.ProductOrders.FindAsync(id);
            if (productOrders == null)
            {
                return NotFound();
            }

            _context.ProductOrders.Remove(productOrders);
            await _context.SaveChangesAsync();

            return productOrders;
        }

        private bool ProductOrdersExists(int id)
        {
            return _context.ProductOrders.Any(e => e.Id == id);
        }
    }
}
