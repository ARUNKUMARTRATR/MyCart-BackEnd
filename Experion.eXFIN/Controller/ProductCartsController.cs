using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Experion.MyCart.Data.Entities;

namespace Experion.MyCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCartsController : ControllerBase
    {
        private readonly MyCartDBContext _context;

        public ProductCartsController(MyCartDBContext context)
        {
            _context = context;
        }


        // GET: api/ProductCarts/5
        [HttpGet("{userId}")]
        public IEnumerable<Products> GetProductCart(int userId)
        {
            var productCartItems = _context.ProductCart.Where(x => x.UserId == userId).ToList();

            var productIds = productCartItems.Select(x => x.CartProductId).ToList();

           
                productIds.Remove("0");
                if (productIds.Count() != 0)
                {
                    var productList = _context.Products.Where(x => productIds.Contains(x.ProductId)).ToArray();
                    return productList;
                }
                else
                {
                    var productList = new List<Products>();
                    return productList;
                }
            
          
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductCart>>PostProductCart(ProductCart productCart)
        {
            try
            {
                var productCount = _context.ProductCart.Where(x => x.UserId == productCart.UserId && x.CartProductId == productCart.CartProductId).Select(x => x.ProductCount).FirstOrDefault();



                if (productCount != 0)
                {
                    var CartId = _context.ProductCart.Where(x => x.UserId == productCart.UserId && x.CartProductId == productCart.CartProductId).Select(x => x.Id).FirstOrDefault();
                    var pCart = await _context.ProductCart.FindAsync(CartId);

                    productCount = productCount + 1;

                    pCart.ProductCount = productCount;
                    _context.ProductCart.Update(pCart);
                     _context.SaveChanges();
                    return pCart;
                }
                else
                {
                    var pCart = new ProductCart
                    {
                        UserId = productCart.UserId,
                        CartProductId = productCart.CartProductId,
                        ProductCount = 1
                    };
                    _context.ProductCart.Add(pCart);
                    _context.SaveChanges();
                    return pCart;
                }
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpPost("remove")]
        public async Task<ActionResult<ProductCart>> DeleteProductCart(ProductCart productCart)
        {
            var Id = _context.ProductCart.Where(x => x.UserId == productCart.UserId && x.CartProductId == productCart.CartProductId).Select(x => x.Id).FirstOrDefault();
            var pCart = await _context.ProductCart.FindAsync(Id);
            if (pCart == null)
            {
                return NotFound();
            }

            _context.ProductCart.Remove(pCart);
            await _context.SaveChangesAsync();

            return pCart;
        }

        private bool ProductCartExists(int id)
        {
            return _context.ProductCart.Any(e => e.Id == id);
        }
    }
}
