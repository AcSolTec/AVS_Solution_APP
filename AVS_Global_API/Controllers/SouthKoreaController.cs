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
    public class SouthKoreaController : ControllerBase
    {
        [HttpPost]
        [Route("SavePersonalInfo")]
        public IActionResult SaveConctacDetails(Models.TbSkPersonalInf model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var personalEntity = context.TbSkPersonalInfs.FirstOrDefault(x => x.IdForm == model.IdForm);

                if (personalEntity != null)
                {
                    personalEntity.IdCountry = model.IdCountry;
                    personalEntity.BitSex = model.BitSex;
                    personalEntity.NamePassport = model.NamePassport;
                    personalEntity.BitNameUknown = model.BitNameUknown;
                    personalEntity.Surname = model.Surname;
                    personalEntity.BitSurNamUknown = model.BitSurNamUknown;
                    personalEntity.PassportNum = model.PassportNum;
                    personalEntity.DateBirth = model.DateBirth;
                    personalEntity.DateExpiredPassport = model.DateExpiredPassport;
                }
                else
                {
                    var skpi = new Models.TbSkPersonalInf();
                    skpi.IdForm = model.IdForm;
                    skpi.IdCountry = model.IdCountry;
                    skpi.BitSex = model.BitSex;
                    skpi.NamePassport = model.NamePassport;
                    skpi.BitNameUknown = model.BitNameUknown;
                    skpi.Surname = model.Surname;
                    skpi.BitSurNamUknown = model.BitSurNamUknown;
                    skpi.PassportNum = model.PassportNum;
                    skpi.DateBirth = model.DateBirth;
                    skpi.DateExpiredPassport = model.DateExpiredPassport;
                    context.TbSkPersonalInfs.Add(skpi);
                }


                context.SaveChanges();
                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpGet]
        [Route("getDataPersonalInfo")]
        public Models.TbSkPersonalInf getDataPersonalInfo(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbSkPersonalInf pi = db.TbSkPersonalInfs.FirstOrDefault(d => d.IdForm == idForm);
                return pi;
            }
        }
    }
}
