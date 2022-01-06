using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubaController : ControllerBase
    {
        [HttpPost]
        [Route("SaveConctacDetails")]
        public IActionResult SaveConctacDetails(Entities.encuSaveConctactDetails model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var contactEntity = context.TbCuContactDetails.FirstOrDefault(x => x.IdForm == model.idForm);

                if (contactEntity != null)
                {
                    contactEntity.FirstName = model.firstName;
                    contactEntity.SurName = model.surName;
                    contactEntity.Address = model.address;
                    contactEntity.ZipCode = model.zipCode;
                    contactEntity.Town = model.town;
                    contactEntity.EmailAddress = model.emailAddress;
                    contactEntity.TelNumber = model.telNumber;
                }
                else
                {
                    var cubcd = new Models.TbCuContactDetail();
                    cubcd.IdForm = model.idForm;
                    cubcd.FirstName = model.firstName;
                    cubcd.SurName = model.surName;
                    cubcd.Address = model.address;
                    cubcd.ZipCode = model.zipCode;
                    cubcd.Town = model.town;
                    cubcd.EmailAddress = model.emailAddress;
                    cubcd.TelNumber = model.telNumber;
                    context.TbCuContactDetails.Add(cubcd);
                }


                context.SaveChanges();



                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SaveTripShipp")]
        public IActionResult SaveTripShipp(Entities.encuSaveTripShipp model)
        {

            string msjeOut = string.Empty;



            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var tripShippEntity = context.TbCuTravShipDets.FirstOrDefault(x => x.IdForm == model.idForm);

                if (tripShippEntity != null)
                {
                    tripShippEntity.DateEntryCuba = model.dateEntryCuba;
                    tripShippEntity.DateDeparture = model.dateDeparture;
                    tripShippEntity.NumsAdults = model.numsAdults;
                    tripShippEntity.NumsChildrens = model.numsChildrens;
                    tripShippEntity.PassportAdult = model.passportAdult;
                    tripShippEntity.PassportChildren = model.passportChildren;
                    tripShippEntity.BitShippDifferent = model.bitShippDifferent;
                    tripShippEntity.BitPpchf5 = model.bitPpchf5;
                    tripShippEntity.BitRschf750 = model.bitRschf750;
                    tripShippEntity.BitEschf22 = model.bitEschf22;
                    tripShippEntity.BitCourierNatInt = model.bitCourierNatInt;
                }
                else
                {
                    var cubtriShipp = new Models.TbCuTravShipDet();
                    cubtriShipp.IdForm = model.idForm;
                    cubtriShipp.DateEntryCuba = model.dateEntryCuba;
                    cubtriShipp.DateDeparture = model.dateDeparture;
                    cubtriShipp.NumsAdults = model.numsAdults;
                    cubtriShipp.NumsChildrens = model.numsChildrens;
                    cubtriShipp.PassportAdult = model.passportAdult;
                    cubtriShipp.PassportChildren = model.passportChildren;
                    cubtriShipp.BitShippDifferent = model.bitShippDifferent;
                    cubtriShipp.BitPpchf5 = model.bitPpchf5;
                    cubtriShipp.BitRschf750 = model.bitRschf750;
                    cubtriShipp.BitEschf22 = model.bitEschf22;
                    cubtriShipp.BitCourierNatInt = model.bitCourierNatInt;
                    context.TbCuTravShipDets.Add(cubtriShipp);
                }


                context.SaveChanges();



                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("recieveImagesCuba")]
        public IActionResult RecieveImages(IList<IFormFile> files, int idForm)
        {
            string message = string.Empty;
            using (var context = new Models.AVS_DBContext())
            {
                byte[] passportAdult = null;
                byte[] passportChild = null;
                
                var tripShippEntity = context.TbCuTravShipDets.FirstOrDefault(x => x.IdForm == idForm);

                if (tripShippEntity != null)
                {

                    using (var ms = new MemoryStream())
                    {
                        files[0].CopyTo(ms);
                        var fileBytesAd = ms.ToArray();
                        passportAdult = fileBytesAd;
                    }

                    using (var ms = new MemoryStream())
                    {
                        files[1].CopyTo(ms);
                        var fileBytesChi = ms.ToArray();
                        passportChild = fileBytesChi;
                    }


                    tripShippEntity.PassportAdult = passportAdult;
                    tripShippEntity.PassportChildren = passportChild;
                    context.SaveChanges();
                    message = "OK";
                }
                else
                {
                    message = "Not idForm Provider";
                }


            }
            return Ok(message);
        }

        [HttpPost]
        [Route("SaveSummary")]
        public IActionResult SaveSummary(Entities.encuSaveSummary model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var sumEntity = context.TbCuSummaries.FirstOrDefault(x => x.IdForm == model.idForm);

                if (sumEntity != null)
                {
                    sumEntity.Comments = model.comments;
                    sumEntity.BitReadSucc = model.bitReadSucc;
                    sumEntity.BitReadGtc = model.bitReadGtc;
                }
                else
                {
                    var summ = new Models.TbCuSummary();
                    summ.IdForm = model.idForm;
                    summ.Comments = model.comments;
                    summ.BitReadSucc = model.bitReadSucc;
                    summ.BitReadGtc = model.bitReadGtc;
                    context.TbCuSummaries.Add(summ);
                }


                context.SaveChanges();



                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpGet]
        [Route("cdCuIdForm")]
        public Models.TbCuContactDetail GetContactData(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbCuContactDetail contacts = db.TbCuContactDetails.FirstOrDefault(d => d.IdForm == idForm);
                return contacts;
            }
        }

        [HttpGet]
        [Route("tsCuIdForm")]
        public Models.TbCuTravShipDet GetTripShippData(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbCuTravShipDet tripShipp = db.TbCuTravShipDets.FirstOrDefault(d => d.IdForm == idForm);
                return tripShipp;
            }
        }
    }
}
