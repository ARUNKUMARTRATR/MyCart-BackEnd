using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Experion.MyCart.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Experion.MyCart.Data.Model;
using System;

namespace Experion.MyCart.Controller
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyCartDBContext _context;

        public ProductsController(MyCartDBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            try
            {
                var products = await _context.Products.Where(x => x.IsDeleted != true).ToListAsync();
                return products;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // GET: api/Products/----updating product
        [HttpPut]
        public async Task<ActionResult<Products>> PutProducts([FromBody] ProductModel productData)
        {
            var id = _context.Products.Where(x => x.ProductId == productData.ProductId).Select(x => x.Id).FirstOrDefault();
            var product = await _context.Products.FindAsync(id);
            var catId = _context.Catogory.Where(x => x.Catogories == productData.CatogoryName).Select(x => x.CatogoryId).FirstOrDefault();
            try
            {

                if (product == null)
                {
                    return NotFound();
                }

                product.ProductName = productData.ProductName;
                product.ProductId = productData.ProductId;
                product.IsDeleted = false;
                product.PhotoUrl = productData.PhotoUrl;
                product.Price = productData.Price;
                product.LaunchDate = productData.LaunchDate;
                product.IsAvailable = productData.IsAvailable;
                product.CatogoryId = catId;
                product.Description = productData.Description;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // GET: api/Products/----adding product
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts([FromBody] ProductModel productData)
        {

            var pName = _context.Products.Where(x => x.ProductId == productData.ProductId).Select(x => x.ProductName).FirstOrDefault();
            var catId = _context.Catogory.Where(x => x.Catogories == productData.CatogoryName).Select(x => x.CatogoryId).FirstOrDefault();


            try
            {
                if (pName != null)
                {
                    return BadRequest();
                }
                else
                {
                    var productAdd = new Products
                    {
                        ProductId = productData.ProductId,
                        ProductName = productData.ProductName,
                        Description = productData.Description,
                        Price = productData.Price,
                        LaunchDate = productData.LaunchDate,
                        PhotoUrl = productData.PhotoUrl,
                        IsAvailable = productData.IsAvailable,
                        IsDeleted = productData.IsDeleted,
                        CatogoryId = catId
                    };

                    _context.Products.Add(productAdd);
                    await _context.SaveChangesAsync();
                    return productAdd;
                }
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }


        }

        // GET: api/Products/----delete product
        [HttpDelete("{productId}")]
        public async Task<ActionResult<Products>> DeleteProducts(string productId)
        {
            try
            {
                var id = _context.Products.Where(x => x.ProductId == productId).Select(x => x.Id).FirstOrDefault();
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                product.IsDeleted = true;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
