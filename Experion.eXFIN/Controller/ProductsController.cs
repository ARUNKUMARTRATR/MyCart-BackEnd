using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Experion.MyCart.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Experion.MyCart.Data.Model;

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
            return await _context.Products.Where(x => x.IsDeleted != true).ToListAsync();
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

        [HttpPut]
        public async Task<ActionResult<Products>> PutProducts([FromBody] ProductModel productData)
        {
            var id = _context.Products.Where(x => x.ProductId == productData.ProductId).Select(x => x.Id).FirstOrDefault();
            var catid = _context.Products.Where(x => x.ProductId == productData.ProductId).Select(x => x.CatogoryId).FirstOrDefault();

            var product = await _context.Products.FindAsync(id);

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
            product.CatogoryId = catid;
            product.Description = productData.Description;



            try
            {
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

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts([FromBody] ProductModel productsData)
        {

            var productNew = new Products();
            var pName = _context.Products.Where(x => x.ProductId == productsData.ProductId).Select(x => x.ProductName).FirstOrDefault();
            if (pName == null)
            {
                var temp = _context.Catogory.Where(x => x.Catogories == productsData.CatogoryName).FirstOrDefault();
                if (temp == null)
                {
                    var cat = new Catogory { Catogories = productsData.CatogoryName.ToLower() };
                    _context.Catogory.Add(cat);
                    await _context.SaveChangesAsync();
                    var catid = _context.Catogory.Where(x => x.Catogories == productsData.CatogoryName.ToLower()).Select(x => x.CatogoryId).FirstOrDefault();

                    productNew.ProductName = productsData.ProductName;
                    productNew.ProductId = productsData.ProductId;
                    productNew.Description = productsData.Description;
                    productNew.Price = productsData.Price;
                    productNew.LaunchDate = productsData.LaunchDate.ToString();
                    productNew.PhotoUrl = productsData.PhotoUrl;
                    productNew.IsAvailable = productsData.IsAvailable;
                    productNew.IsDeleted = false;
                    productNew.CatogoryId = catid;
                    
                    _context.Products.Add(productNew);
                    await _context.SaveChangesAsync();
                    return productNew;

                }
                else
                {
                    var catid = _context.Catogory.Where(x => x.Catogories == productsData.CatogoryName.ToLower()).Select(x => x.CatogoryId).FirstOrDefault();

                    productNew.ProductName = productsData.ProductName;
                    productNew.ProductId = productsData.ProductId;
                    productNew.Description = productsData.Description;
                    productNew.Price = productsData.Price;
                    productNew.LaunchDate = productsData.LaunchDate.ToString();
                    productNew.PhotoUrl = productsData.PhotoUrl;
                    productNew.IsAvailable = productsData.IsAvailable;
                    productNew.IsDeleted = false;
                    productNew.CatogoryId = catid;
                    
                    _context.Products.Add(productNew);
                    await _context.SaveChangesAsync();
                    return productNew;
                }

            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<Products>> DeleteProducts(string productId)
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

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
