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
    public class FormulariesController : ControllerBase
    {
        [HttpGet]
        [Route("getFormsCustomers")]
        public IEnumerable<dynamic> GetFormsCustomers(string mailAccount)
        {
            using (var db = new Models.AVS_DBContext())
            {



                var formularies = (from forms in db.TbFormularies
                                   join countries in db.TbCountries on forms.IdCountry equals countries.IdCountry
                                   join customers in db.TbCustomersAvs on forms.IdCustomer equals customers.IdCustomer
                                   join statusForms in db.TbStatusForms on forms.IdStatus equals statusForms.IdStatus
                                   where (forms.IdStatus == 1 && customers.RegisteredMail == mailAccount)
                                   select new { IdForm = forms.IdForm, Country = countries.Name, Customer = customers.RegisteredMail, Status = statusForms.Description }).ToList();



                return formularies;
            }
        }
    }
}
