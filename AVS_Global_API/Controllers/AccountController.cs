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
            Entities.enResponseCustomers response = new Entities.enResponseCustomers();
            if (_admin.Any())
            {

                Helpers.EncryptingService encryptor = new Helpers.EncryptingService();
               

                var pass = db.TbCustomersAvs.Where(s => s.RegisteredMail == model.Mail).Select(d => d.Pass).ToList();
                var seed = db.TbCustomersAvs.Where(s => s.RegisteredMail == model.Mail).Select(d => d.Seed).ToList();
                var Key = encryptor.DecryptString128Bit(pass[0].ToString(), seed[0].ToString()).Replace("\0", "");

                var query = (from country in db.TbCustomersAvs
                            join countries in db.TbCountries on country.IdCountry equals countries.IdCountry
                            where country.RegisteredMail == model.Mail
                            select new { Country = countries.Name }).ToList();

               

                if (Key == model.Pass)
                {
                    
                    response.loginSuccess = true;
                    response.Message = "Login Successfull!";
                    response.CountryLog = query[0].Country.ToString();

                    return Ok(response);
                }
                else
                {
                    response.loginSuccess = false;
                    response.Message = "Invalid Password";
                    response.CountryLog = "";

                    return Ok(response);

                }
            }
            else
            {
                response.loginSuccess = false;
                response.Message = "Invalid Email!";
                response.CountryLog = "";

                return Ok(response);
            }
        }

        [HttpPost]
        [Route("SaveAccount")]
        public IActionResult SaveCustomer(Entities.enTbCustomersAvs model)
        {


            Helpers.EncryptingService encryptor = new Helpers.EncryptingService();

            var passEncrypt = encryptor.EncryptString128Bit(model.Pass, "customerseed");

            var result = Data.CustomersData.InsertCustomer(model.IdCountry, model.RegisteredMail, passEncrypt);
            string msjeOut = string.Empty;
            if (result == "OK")
            {
                msjeOut = "Customer created";
            }
            else
            {
                msjeOut = "Customer failed";
            }

            return Ok(msjeOut);

        }

        [HttpGet]
        [Route("CatCountriesCustomer")]
        public IEnumerable<Models.TbCountry> GetCountries()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCountry> countries = db.TbCountries.Where(d => d.BitActive == true).ToList();
                return countries;
            }
        }

    }
}
