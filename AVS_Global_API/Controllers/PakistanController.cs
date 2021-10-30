using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AVS_Global_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PakistanController : ControllerBase
    {

        //Testing
        [HttpGet]
        public IEnumerable<Models.TbCountry> Get()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCountry> countries = db.TbCountries.Where(d => d.BitActive == true).ToList();
                return countries;
            }
        }


        [HttpPost]
        public IActionResult SaveCustomer(Entities.enTbCustomersAvs model)
        {


            Helpers.EncryptingService encryptor = new Helpers.EncryptingService();

            var passEncrypt = encryptor.EncryptString128Bit(model.Pass, "customerseed");

            var result = Data.CustomersData.InsertCustomer(model.IdCountry, model.RegisteredMail, passEncrypt);
            string msjeOut = string.Empty;
            if(result == "OK")
            {
                msjeOut = "Customer created";
            }
            else
            {
                msjeOut = "Customer failed";
            }

            return Ok(msjeOut);

        }


        //[HttpPost]
        //public IActionResult SaveForm(int IdCountry, string Mail, string Pass)
        //{

        //    var result = Data.CustomersData.InsertCustomer(IdCountry, Mail, Pass);
        //    string msjeOut = string.Empty;
        //    if (result == "OK")
        //    {
        //        msjeOut = "Customer created";
        //    }
        //    else
        //    {
        //        msjeOut = "Customer failed";
        //    }

        //    return Ok(msjeOut);

        //}



        // GET: api/<PakistanController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PakistanController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PakistanController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PakistanController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PakistanController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
