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
    public class CatalogsController : ControllerBase
    {
        [HttpGet]
        [Route("CatCountries")]
        public IEnumerable<Models.TbCatCountry> GetCountries()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCatCountry> countries = db.TbCatCountries.Where(d => d.BitActive == true).ToList();
                return countries;
            }
        }

        [HttpGet]
        [Route("CatTypesPassport")]
        public IEnumerable<Models.TbTypesPassport> GetTypesPassport()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbTypesPassport> typesPass = db.TbTypesPassports.Where(d => d.BitActive == true).ToList();
                return typesPass;
            }
        }

        [HttpGet]
        [Route("CatPortsInOut")]
        public IEnumerable<Models.TbCatPortsInOut> GetPortsInOut()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCatPortsInOut> PortsInOut = db.TbCatPortsInOuts.Where(d => d.BitActive == true).ToList();
                return PortsInOut;
            }
        }

        [HttpGet]
        [Route("CatPurposes")]
        public IEnumerable<Models.TbCatPurposeVisited> GetPurposes()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbCatPurposeVisited> Purposes = db.TbCatPurposeVisiteds.Where(d => d.BitActive == true).ToList();
                return Purposes;
            }
        }

        [HttpGet]
        [Route("CatCurrentJobs")]
        public IEnumerable<Models.TbSkCatJob> GetCurrentJobs()
        {
            using (var db = new Models.AVS_DBContext())
            {
                IEnumerable<Models.TbSkCatJob> cuJobs = db.TbSkCatJobs.Where(d => d.BitActive == true).ToList();
                return cuJobs;
            }
        }

    }
}
