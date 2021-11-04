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


        [HttpGet]
        public IEnumerable<Models.TbCountry> Get()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCountry> countries = db.TbCountries.Where(d => d.BitActive == true).ToList();
                return countries;
            }
        }



        [HttpGet]
        [Route("CatVisasApplied")]
        public IEnumerable<Models.TbCatTypesVisasApplied> GetCatVisasApplied()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCatTypesVisasApplied> visasApplied = db.TbCatTypesVisasApplieds.Where(d => d.BitActive == true).ToList();
                return visasApplied;
            }
        }


        [HttpGet]
        [Route("VisasRequiered")]
        public IEnumerable<Models.TbCatVisasTime> GetVisasRequiered()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCatVisasTime> visasTimes = db.TbCatVisasTimes.Where(d => d.BitActive == true).ToList();
                return visasTimes;
            }
        }

        [HttpGet]
        [Route("TypesVisas")]
        public IEnumerable<Models.TbCatTypesVisa> GetTypesVisas()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCatTypesVisa> types = db.TbCatTypesVisas.Where(d => d.BitActive == true).ToList();
                return types;
            }
        }

    }
}
