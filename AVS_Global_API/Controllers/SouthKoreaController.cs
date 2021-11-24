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
        public IActionResult SavePersonalInfo(Models.TbSkPersonalInf model)
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

        [HttpPost]
        [Route("SaveInfoReq")]
        public IActionResult SaveInfoReq(Models.TbSkRequiredInf model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var ir = context.TbSkRequiredInfs.FirstOrDefault(x => x.IdForm == model.IdForm);

                if (ir != null)
                {
                    ir.BitOtherNat = model.BitOtherNat;
                    ir.MobileNumber = model.MobileNumber;
                    ir.BitVisitedKorea = model.BitVisitedKorea;
                    ir.IdCountry = model.IdCountry;
                    ir.PostalCode = model.PostalCode;
                    ir.AddressPostal = model.AddressPostal;
                    ir.NumberContactKorea = model.NumberContactKorea;
                    ir.IdJob = model.IdJob;
                    ir.BitInfectiuos15 = model.BitInfectiuos15;
                    ir.BitArrested = model.BitArrested;
                    ir.SponsorName = model.SponsorName;
                    ir.AddressNumber = model.AddressNumber;
                    ir.ZipCode = model.ZipCode;
                    ir.City = model.City;
                }
                else
                {
                    var skir = new Models.TbSkRequiredInf();
                    skir.IdForm = model.IdForm;
                    skir.BitOtherNat = model.BitOtherNat;
                    skir.MobileNumber = model.MobileNumber;
                    skir.BitVisitedKorea = model.BitVisitedKorea;
                    skir.IdCountry = model.IdCountry;
                    skir.PostalCode = model.PostalCode;
                    skir.AddressPostal = model.AddressPostal;
                    skir.NumberContactKorea = model.NumberContactKorea;
                    skir.IdJob = model.IdJob;
                    skir.BitInfectiuos15 = model.BitInfectiuos15;
                    skir.BitArrested = model.BitArrested;
                    skir.SponsorName = model.SponsorName;
                    skir.AddressNumber = model.AddressNumber;
                    skir.ZipCode = model.ZipCode;
                    skir.City = model.City;
                    context.TbSkRequiredInfs.Add(skir);
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

        [HttpGet]
        [Route("getDataInfoReq")]
        public Models.TbSkRequiredInf getDataInfoReq(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbSkRequiredInf pi = db.TbSkRequiredInfs.FirstOrDefault(d => d.IdForm == idForm);
                return pi;
            }
        }
    }
}
