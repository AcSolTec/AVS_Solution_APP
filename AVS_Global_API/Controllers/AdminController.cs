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
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Route("getFormsAuth")]
        public IEnumerable<dynamic> GetFormsAuth()
        {
            using (var db = new Models.AVS_DBContext())
            {



                var formularies = (from forms in db.TbFormularies
                                   join countries in db.TbCountries on forms.IdCountry equals countries.IdCountry
                                   join customers in db.TbCustomersAvs on forms.IdCustomer equals customers.IdCustomer
                                   join statusForms in db.TbStatusForms on forms.IdStatus equals statusForms.IdStatus
                                   where forms.IdStatus == 1
                                   select new { IdForm = forms.IdForm, Country = countries.Name, Customer = customers.RegisteredMail, Status = statusForms.Description }).ToList();

                

                return formularies;
            }
        }

        [HttpPost]
        [Route("ReviewFormAccepted")]
        public IActionResult ReviewFormAccepted(int idform)
        {
            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var modelForm = context.TbFormularies.FirstOrDefault(x => x.IdForm == idform);

                if (modelForm != null)
                {
                    modelForm.IdStatus = 4; // Approved
                }

                context.SaveChanges();

                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }



    }
}
