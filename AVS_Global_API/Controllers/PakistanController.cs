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

        [HttpPost]
        [Route("SavePersonalDetails")]
        public IActionResult SavePersonalData(Entities.enpkSavePersonalData model)
        {

            var result = Data.Pakistan.PersonalData.InsertPeronalDetails(model);
            string msjeOut = string.Empty;
            if (result == "OK")
            {
                msjeOut = "Personal data saved";
            }
            else
            {
                msjeOut = "Personal data failed";
            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SaveAppDetails")]
        public IActionResult SaveApplicantsData(Entities.enpkSaveAppDetails model)
        {

            var result = Data.Pakistan.AppDetails.InsertAppDetails(model);
            string msjeOut = string.Empty;
            if (result == "OK")
            {
                msjeOut = "Applicants data saved";
            }
            else
            {
                msjeOut = "Applicants data failed";
            }

            return Ok(msjeOut);
        }


        [HttpPost]
        [Route("SavePassportDetails")]
        public IActionResult SavePassportData(Entities.enpkSavePassportData model)
        {

            var result = Data.Pakistan.PassportDetails.InsertPassportDetails(model);
            string msjeOut = string.Empty;
            if (result == "OK")
            {
                msjeOut = "Passport data saved";
            }
            else
            {
                msjeOut = "Passport data failed";
            }

            return Ok(msjeOut);
        }


        [HttpPost]
        [Route("SaveContactDetails")]
        public IActionResult SaveContactData(Entities.enpkSaveConctactDetails model)
        {

            var result = Data.Pakistan.ConctactDetails.InsertConctactDetails(model);
            string msjeOut = string.Empty;
            if (result == "OK")
            {
                msjeOut = "Conctact data saved";
            }
            else
            {
                msjeOut = "Conctact data failed";
            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SavePastJobs")]
        public IActionResult SavePastJobs(Entities.enpkSavePastJobs model)
        {

            var result = Data.Pakistan.PastJobs.InsertPastJobs(model);
            string msjeOut = string.Empty;
            if (result == "OK")
            {
                msjeOut = "PastJobs data saved";
            }
            else
            {
                msjeOut = "PastJobs data failed";
            }

            return Ok(msjeOut);
        }


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
