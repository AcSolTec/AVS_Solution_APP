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

            Entities.enResponseCustomers response = new Entities.enResponseCustomers();
            Helpers.EncryptingService encryptor = new Helpers.EncryptingService();
            //First to validate if user is admin..
            #region validateAdminUs
            var sesAdmin = db.TbUsers.Where(s => s.KeyAccess == model.Mail);

            if (sesAdmin.Any())
            {

                var pass = db.TbUsers.Where(s => s.KeyAccess == model.Mail).Select(d => d.Pass).ToList();
                var seed = db.TbUsers.Where(s => s.KeyAccess == model.Mail).Select(d => d.Seed).ToList();
                var Key = encryptor.DecryptString128Bit(pass[0].ToString(), seed[0].ToString()).Replace("\0", "");

                if (Key == model.Pass)
                {

                    var _rol = (from role in db.TbUsers
                                join roles in db.TbRoles on role.IdRol equals roles.IdRol
                                where role.KeyAccess == model.Mail
                                select new { rolAssig = roles.NameRol });

                    response.loginSuccess = true;
                    response.Message = "Login Successfull!";
                    response.CountryLog = "";
                    response.IdForm = "";
                    response.rol = _rol.FirstOrDefault().rolAssig;

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
                response.rol = "";
            }


            #endregion

            var _admin = db.TbCustomersAvs.Where(s => s.RegisteredMail == model.Mail);

            if (_admin.Any())
            {


                var pass = db.TbCustomersAvs.Where(s => s.RegisteredMail == model.Mail).Select(d => d.Pass).ToList();
                var seed = db.TbCustomersAvs.Where(s => s.RegisteredMail == model.Mail).Select(d => d.Seed).ToList();
                var Key = encryptor.DecryptString128Bit(pass[0].ToString(), seed[0].ToString()).Replace("\0", "");

                var query = (from country in db.TbCustomersAvs
                             join countries in db.TbCountries on country.IdCountry equals countries.IdCountry
                             where country.RegisteredMail == model.Mail
                             select new { Country = countries.Name }).ToList();

                var queryGetForm = (from customers in db.TbCustomersAvs
                                    join formularies in db.TbFormularies on customers.IdCustomer equals formularies.IdCustomer
                                    where customers.RegisteredMail == model.Mail
                                    select new { IdForm = formularies.IdForm }).ToList();



                if (Key == model.Pass)
                {

                    response.loginSuccess = true;
                    response.Message = "Login Successfull!";
                    response.CountryLog = query[0].Country.ToString();
                    response.IdForm = queryGetForm[0].IdForm.ToString();

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
                response.rol = "";

            }

            return Ok(response);
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
