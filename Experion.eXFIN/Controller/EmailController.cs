using System.Collections.Generic;
using System.Net.Mail;
using Experion.MyCart.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Experion.MyCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
       

        // POST: api/Email
        [HttpPost("{userId}")]
        public IActionResult Post([FromBody] Products product, string userId)
        {

            MailMessage mail = new MailMessage("mycart.experion@gmail.com", "arunkumartr95@gmail.com");

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);

            mail.Subject = "Notification For Product Order";

            //mail.Body = "<p> Hi</p> <p>"+"" + email.message +"</p> <div style='margin-top: 70px;'><span style='color: rgb(135, 135, 236);'>Thanks & Regards,<br></span><div><p>" + "" + email.UserName + "" + "</p><span style='border-right: 3px solid rgb(247, 228, 56);color: rgb(135, 135, 236);padding-right: 5px;'>Team Talent Acquisition</span><span style='border-right: 3px solid rgb(247, 228, 56);color: rgb(135, 135, 236);padding-right: 5px;padding-left: 5px;'>Experion Technologies</span><span style='border-right: 3px solid rgb(247, 228, 56);color: rgb(99, 195, 240);padding-right: 5px;padding-left: 5px;'>Technopark – Trivandrum </span><span style='border-right: 3px solid rgb(247, 228, 56);color: rgb(212, 65, 231);padding-right: 5px;padding-left: 5px;'>www.experionglobal.com</span></div></div>";
            mail.Body = "<p>Hi&nbsp;&nbsp;Arunkumar TR</p><div style='margin-left:30px;'><p> Your Order Successfully Placed!</p><p>OrderDetails :<div style='margin-left:20px;'>message<br>message</div></p></div><div style ='margin-top: 70px;'><span style ='color: rgb(135, 135, 236);'> Thanks & Regards,<br></span><div><p>MyCart Team</p><span style = 'border-right: 3px solid rgb(247, 228, 56);color: green;padding-right: 5px;padding-left: 5px;'>MyCart</span><span style = 'border-right: 3px solid rgb(247, 228, 56);color: rgb(2, 253, 65);padding-right: 5px;padding-left: 5px;'>www.MyCart.com</span></div></div>";

            mail.IsBodyHtml = true;

            SmtpServer.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "mycart.experion@gmail.com",
                Password = "mycart@1728"
            };

            SmtpServer.EnableSsl = true;


            SmtpServer.Send(mail);
            SmtpServer.Dispose();
            return Ok();
        }
    }
}
