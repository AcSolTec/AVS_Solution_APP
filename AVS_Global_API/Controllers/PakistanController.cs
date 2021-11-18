using Microsoft.AspNetCore.Cors;
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

        [HttpPost]
        [Route("SaveFamilyData")]
        public IActionResult SaveFamilyData(Entities.enpkSaveFamilyData model)
        {

            var result = Data.Pakistan.FamilyData.InsertFamilyDetails(model);
            string msjeOut = string.Empty;

            if (result == "OK")
            {
                msjeOut = "Family data saved";
            }
            else
            {
                msjeOut = "PastJobs data failed";
            }

            return Ok(msjeOut);
        }


        [HttpPost]
        [Route("SaveFamilyChildrens")]
        public IActionResult SaveFamilyChildrensData(List<Entities.enpkChildrensFamily> model)
        {

            //var result = Data.Pakistan.FamilyData.InsertFamilyDetails(model);
            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                var query = (from familiy in context.TbFamilyDetails
                             where familiy.IdForm == model[0].idForm
                             select new { idFam = familiy.IdFam }).ToList();

                List<Models.TbChildrensFamiliy> childrens = new List<Models.TbChildrensFamiliy>();

                //validate if exists
                

                foreach (var item in model)
                {
                    var children = new Models.TbChildrensFamiliy();

                    children.IdFam = query[0].idFam;
                    children.NameChild = item.nameChild;
                    children.DateOfBith = item.dateOfBirth;

                    childrens.Add(children);
                }

                context.TbChildrensFamiliys.AddRange(childrens);
                var entity = context.TbFamilyDetails.FirstOrDefault(x => x.IdForm == model[0].idForm);
                entity.BitChildrens = true;
                context.SaveChanges();
                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SaveFamilyAccomp")]
        public IActionResult SaveFamilyAccompData(List<Entities.enpkSaveFamilySec2> model)
        {

            //var result = Data.Pakistan.FamilyData.InsertFamilyDetails(model);
            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                var query = (from familiy in context.TbFamilyDetails
                             where familiy.IdForm == model[0].idForm
                             select new { idFam = familiy.IdFam }).ToList();

                List<Models.TbAcompanyingFamily> accompLst = new List<Models.TbAcompanyingFamily>();

                //validate if exists

                var accom = context.TbAcompanyingFamilies.Where(x => x.IdFam == query[0].idFam).ToList();

                if (accom.Count > 0)
                {

                    for (int i = 0; i < accom.Count; i++)
                    {
                        accom[i].FullName = model[i].accompName;
                        accom[i].DateOfBirth = model[i].dateOfBirth;
                        accom[i].PassportNumber = model[i].passportNumber;
                        accom[i].Address = model[i].address;
                    }
                }
                else
                {
                    foreach (var item in model)
                    {
                        var accomp = new Models.TbAcompanyingFamily();

                        accomp.IdFam = query[0].idFam;
                        accomp.FullName = item.accompName;
                        accomp.DateOfBirth = item.dateOfBirth;
                        accomp.PassportNumber = item.passportNumber;
                        accomp.Address = item.address;

                        accompLst.Add(accomp);
                    }

                    context.TbAcompanyingFamilies.AddRange(accompLst);
                    var entity = context.TbFamilyDetails.FirstOrDefault(x => x.IdForm == model[0].idForm);
                    entity.BitAcompany = true;
                }

                context.SaveChanges();
                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }


        [HttpPost]
        [Route("SaveFamilyBankData")]
        public IActionResult SaveFamilyBankData(Entities.enpkSaveFamilyBank model)
        {

            var result = Data.Pakistan.FamilyBank.InsertFamilyBankData(model);
            string msjeOut = string.Empty;

            if (result == "OK")
            {
                msjeOut = "Bank data saved";
            }
            else
            {
                msjeOut = "Bank data failed";
            }

            return Ok(msjeOut);
        }


        [HttpPost]
        [Route("SaveTravelData")]
        public IActionResult SaveTravelData(Entities.enpkTravelBits model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var travelEntity = context.TbTravelHistoryData.FirstOrDefault(x => x.IdForm == model.idForm);

                if (travelEntity != null)
                {
                    travelEntity.BitRefused = model.bitRefused;
                    travelEntity.BitRefusedPakistan = model.bitRefusedPakistan;
                    travelEntity.BitRemoveCountry = model.bitRemoveCountry;
                    travelEntity.BitConviction = model.bitConviction;
                    travelEntity.DetailRefusal = model.detailRefusal;
                }
                else
                {
                    var travel = new Models.TbTravelHistoryDatum();
                    travel.IdForm = model.idForm;
                    travel.BitRefusedPakistan = model.bitRefusedPakistan;
                    travel.BitRemoveCountry = model.bitRemoveCountry;
                    travel.BitConviction = model.bitConviction;
                    travel.DetailRefusal = model.detailRefusal;
                    context.TbTravelHistoryData.Add(travel);
                }

                
                context.SaveChanges();



                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SaveTravelDeported")]
        public IActionResult SaveTravelDeported(Entities.enpkSaveTravelDeported model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var travelEntity = context.TbDeportedTravels.FirstOrDefault(x => x.IdForm == model.idForm);

                if (travelEntity != null)
                {
                    travelEntity.DateDeport = model.dateDeport;
                    travelEntity.IdCatCountry = model.idCountry;
                    travelEntity.Reason = model.reason;
                    travelEntity.ReferenceNum = model.referenceNum;
                }
                else
                {
                    var travel = new Models.TbDeportedTravel();
                    travel.IdForm = model.idForm;
                    travel.DateDeport = model.dateDeport;
                    travel.IdCatCountry = model.idCountry;
                    travel.Reason = model.reason;
                    travel.ReferenceNum = model.referenceNum;
                    context.TbDeportedTravels.Add(travel);
                }

                context.SaveChanges();
                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SaveTravelConviction")]
        public IActionResult SaveTravelConviction(Entities.enpkSaveTravelConviction model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                //validate if exists
                var travelEntity = context.TbConvictionsTravels.FirstOrDefault(x => x.IdForm == model.idForm);

                if (travelEntity != null)
                {
                    travelEntity.DateConvict = model.dateConvict;
                    travelEntity.IdCatCountry = model.idCountry;
                    travelEntity.Offence = model.offence;
                    travelEntity.Sentence = model.sentence;
                }
                else
                {
                    var travel = new Models.TbConvictionsTravel();
                    travel.IdForm = model.idForm;
                    travel.DateConvict = model.dateConvict;
                    travel.IdCatCountry = model.idCountry;
                    travel.Offence = model.offence;
                    travel.Sentence = model.sentence;
                    context.TbConvictionsTravels.Add(travel);
                }

                context.SaveChanges();
                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }


        [HttpPost]
        [Route("SaveTravel5Years")]
        public IActionResult SaveTravel5years(List<Entities.enpkSaveTravelData> model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                List<Models.TbTravelHisVisitedPk> travelLst = new List<Models.TbTravelHisVisitedPk>();

                //validate if exists

                var travelEntity = context.TbTravelHisVisitedPks.Where(x => x.IdForm == model[0].idForm & x.BitVisPakistan == true).ToList();

                if (travelEntity.Count > 0)
                {

                    for (int i = 0; i < travelEntity.Count; i++)
                    {
                        travelEntity[i].DateTravel = model[i].dateTravel;
                        travelEntity[i].Address = model[i].address;
                        travelEntity[i].Purpose = model[i].purpose;
                        travelEntity[i].Duration = model[i].duration;
                    }
                }
                else
                {
                    foreach (var item in model)
                    {
                        var travel = new Models.TbTravelHisVisitedPk();

                        travel.IdForm = model[0].idForm;
                        travel.DateTravel = item.dateTravel;
                        travel.Address = item.address;
                        travel.Purpose = item.purpose;
                        travel.Duration = item.duration;
                        travel.BitVisPakistan = true;
                        travel.BitVisCountries = false;

                        travelLst.Add(travel);
                    }

                    context.TbTravelHisVisitedPks.AddRange(travelLst);
                }

                context.SaveChanges();
                msjeOut = "OK";

            }

            return Ok(msjeOut);
        }

        [HttpPost]
        [Route("SaveTravel2Years")]
        public IActionResult SaveTravel2years(List<Entities.enpkSaveTravelData> model)
        {

            string msjeOut = string.Empty;

            using (var context = new Models.AVS_DBContext())
            {

                List<Models.TbTravelHisVisitedPk> travelLst = new List<Models.TbTravelHisVisitedPk>();

                //validate if exists

                var travelEntity = context.TbTravelHisVisitedPks.Where(x => x.IdForm == model[0].idForm & x.BitVisCountries == true).ToList();

                if (travelEntity.Count > 0)
                {

                    for (int i = 0; i < travelEntity.Count; i++)
                    {
                        travelEntity[i].DateTravel = model[i].dateTravel;
                        travelEntity[i].Address = model[i].address;
                        travelEntity[i].Purpose = model[i].purpose;
                        travelEntity[i].Duration = model[i].duration;
                    }
                }
                else
                {
                    foreach (var item in model)
                    {
                        var travel = new Models.TbTravelHisVisitedPk();

                        travel.IdForm = model[0].idForm;
                        travel.DateTravel = item.dateTravel;
                        travel.Address = item.address;
                        travel.Purpose = item.purpose;
                        travel.Duration = item.duration;
                        travel.BitVisCountries = true;
                        travel.BitVisPakistan = false;
                        

                        travelLst.Add(travel);
                    }

                    context.TbTravelHisVisitedPks.AddRange(travelLst);
                }

                context.SaveChanges();
                msjeOut = "OK";

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

        [HttpGet]
        [Route("getDataForm")]
        public Models.TbPersonalDatum GetDataForm(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbPersonalDatum formPak = db.TbPersonalData.FirstOrDefault(d => d.IdForm == idForm);
                return formPak;
            }
        }

        [HttpGet]
        [Route("getDataPassport")]
        public Models.TbPassportDetail GetDataPassport(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbPassportDetail passData = db.TbPassportDetails.FirstOrDefault(d => d.IdForm == idForm);
                return passData;
            }
        }

        [HttpGet]
        [Route("getDataConctact")]
        public Models.TbConctactDetail GetDataContact(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {
                Models.TbConctactDetail ConData = db.TbConctactDetails.FirstOrDefault(d => d.IdForm == idForm);
                return ConData;
            }
        }

        [HttpGet]
        [Route("getDataSponsors")]
        public IEnumerable<Models.TbSponsor> GetDataSponsors(int idForm)
        {
            using (var db = new Models.AVS_DBContext())
            {

                var modSponsors = (from cdetails in db.TbConctactDetails
                             join spon in db.TbSponsors on cdetails.IdConctact equals spon.IdConctact
                             where cdetails.IdForm == idForm
                             select new { idContact = spon.IdConctact });

               IEnumerable<Models.TbSponsor> ConDataSpon = db.TbSponsors.Where(d => d.IdConctact == modSponsors.FirstOrDefault().idContact).ToList();
                return ConDataSpon;
            }
        }

    }
}
