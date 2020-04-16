using System.Linq;
using Experion.MyCart.Data.Entities;
using Experion.MyCart.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Experion.MyCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyCartDBContext _context;

        public LoginController(MyCartDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public object Login([FromBody] loginModel value)
        {
            try
            {
                var userData = _context.Users.Where(x => x.Email == value.email).FirstOrDefault();
                if (userData != null)
                {
                    var productCount = _context.ProductCart.Where(x => x.UserId == userData.UserId).Select(x => x.ProductCount).ToList().Sum();

                    var returnUser = new loginModel
                    {
                        email = userData.Email,
                        fullName = userData.FullName,
                        photoUrl = userData.PhotoUrl,
                        cartCount = productCount
                    };
                    return returnUser;
                }
                else
                {
                    var user = new Users
                    {
                        Email = value.email,
                        FullName = value.fullName,
                        FName = value.fName,
                        LName = value.lName,
                        PhotoUrl = value.photoUrl,
                        MobileNo = null

                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    var newUserId = _context.Users.Where(x => x.Email == value.email).Select(x => x.UserId).FirstOrDefault();
                    var productCart = new ProductCart
                    {
                        UserId = newUserId,
                        ProductCount = 0,
                        CartProductId = null
                    };
                    _context.ProductCart.Add(productCart);
                    _context.SaveChanges();

                    var returnUser = new loginModel
                    {
                        email = value.email,
                        fullName = value.fullName,
                        photoUrl = value.photoUrl,
                        cartCount = 0
                    };
                    return returnUser;
                }
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
            
        }
    }
}
