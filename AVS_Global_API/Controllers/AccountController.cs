using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        Models.AVS_DBContext db = new Models.AVS_DBContext();
        [HttpPost]
        public IActionResult ValidateCustomer(Entities.enAccountsCustomerscs model)
        {
            var _admin = db.TbCustomersAvs.Where(s => s.RegisteredMail == model.Mail);
            if (_admin.Any())
            {

                Helpers.EncryptingService encryptor = new Helpers.EncryptingService();
                var pass = db.TbCustomersAvs.Select(d => d.Pass).ToList();
                var seed = db.TbCustomersAvs.Select(d => d.Seed).ToList();
                var Key = encryptor.DecryptString128Bit(pass[0].ToString(), seed[0].ToString()).Replace("\0", "");

                if (Key == model.Pass)
                {
                    return Ok("Login Successfull!");
                }
                else
                {
                    return Ok("Invalid Password!");

                }
            }
            else
            {
                return Ok("Invalid Email!");
            }
        }
    }
}
