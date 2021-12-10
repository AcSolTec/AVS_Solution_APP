using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AVS_Global.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;

namespace AVS_Global.Controllers
{
    public class FormulariesController : Controller
    {

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(1)
                    }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult FormPakistan()
        {
            const string urlApiPakistan = "https://localhost:44330/api/Pakistan/";
            const string urlApiCatalogs = "https://localhost:44330/api/Catalogs/";

            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewBag.Form = HttpContext.Session.GetString("_Form");
            ViewBag.CountryName = HttpContext.Session.GetString("_CountryName");
            ViewData["User"] = ViewBag.Name;
            ViewData["Form"] = ViewBag.Form;
            ViewData["imgForm"] = "/flags/PK.png";


            if (ViewData["User"] != null)
            {



                #region CallCatVisasApplied
                var client = new RestClient(urlApiPakistan + "CatVisasApplied");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.GET);
                var response = client.Execute<List<Models.CatVisasApplied>>(request);
                ViewBag.items = response.Data;
                #endregion

                #region CallCatVisasRequired
                //Visa requiered
                var clientReq = new RestClient(urlApiPakistan + "VisasRequiered");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responseReq = clientReq.Execute<List<Models.CatVisasRequiered>>(request);

                ViewBag.itemsReq = responseReq.Data;
                #endregion

                #region CallCatTypesVisas
                //Visa requiered
                var clientType = new RestClient(urlApiPakistan + "TypesVisas");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responseType = clientType.Execute<List<Models.CatTypeVisas>>(request);
                ViewBag.itemsType = responseType.Data;
                #endregion

                #region CallCatCountries
                //Visa requiered
                var clientCountry = new RestClient(urlApiCatalogs + "CatCountries");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responseCtry = clientCountry.Execute<List<Models.CatCountries>>(request);
                ViewBag.itemsCountries = responseCtry.Data;
                #endregion

                #region CallCatTypesPass
                //Visa requiered
                var clientTypesPass = new RestClient(urlApiCatalogs + "CatTypesPassport");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responseTypesPass = clientTypesPass.Execute<List<Models.CatTypesPassports>>(request);
                ViewBag.itemsTypesPass = responseTypesPass.Data;
                #endregion

                #region CallCatPurpose
                //Visa requiered
                var clientPurpose = new RestClient(urlApiCatalogs + "CatPurposes");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responsePurpose = clientPurpose.Execute<List<Models.CatPurposes>>(request);
                int IdCountryPK = 1;
                ViewBag.itemsPurposes = responsePurpose.Data.Where(x => x.IdCountry == IdCountryPK);
                #endregion

                #region CallCatPortsInOut
                //Visa requiered
                var clientPortsInOut = new RestClient(urlApiCatalogs + "CatPortsInOut");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responsePortsInOut = clientPortsInOut.Execute<List<Models.CatsPortsInOut>>(request);
                ViewBag.itemsPorts = responsePortsInOut.Data;
                #endregion

                #region getDataExists

                //Visa requiered
                var clientPD = new RestClient(urlApiPakistan + "getDataForm?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestget = new RestRequest(Method.GET);
                var responsePD = clientPD.Execute<Models.personalData>(requestget);

                if (responsePD.StatusCode == HttpStatusCode.OK)
                {
                   
                    ViewBag.idVisaAp = responsePD.Data.IdVisaAp;
                    ViewBag.idPurpose = responsePD.Data.IdPurpose;
                    ViewBag.dStay = responsePD.Data.DurationStay;
                    ViewBag.idVisaTime = responsePD.Data.IdVisasTime;
                    ViewBag.idTypeVisa = responsePD.Data.IdTypeVisa;
                    ViewBag.idPortIn = responsePD.Data.IdPortsIn;
                    ViewBag.idPortOut = responsePD.Data.IdPortsOut;
                    ViewBag.pvPakistan = responsePD.Data.Pvpakistan;
                    ViewBag.detProf = responsePD.Data.DetailOfProfesion;

                    // applicants details
                    ViewBag.namePass = responsePD.Data.Name;
                    ViewBag.midName = responsePD.Data.MiddleName;
                    ViewBag.lsName = responsePD.Data.LastName;
                    ViewBag.dtBirth = responsePD.Data.DateBirth;
                    ViewBag.city = responsePD.Data.CityBirth;
                    ViewBag.sex = responsePD.Data.TypeSex;
                    ViewBag.marStat = responsePD.Data.MaritalStatus;
                    ViewBag.blood = responsePD.Data.BloodGroup;
                    ViewBag.idMark = responsePD.Data.IdMark;
                    ViewBag.natLan = responsePD.Data.NativeLanguage;
                    ViewBag.rel = responsePD.Data.Religion;
                    ViewBag.natPresent = responsePD.Data.NationPresent;
                    ViewBag.natPrev = responsePD.Data.NationPrevious;
                    ViewBag.natDual = responsePD.Data.NationDual;


                }

                //Passport Details
                var clientPassDet = new RestClient(urlApiPakistan + "getDataPassport?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestPass = new RestRequest(Method.GET);
                var responsePass = clientPassDet.Execute<Models.pkPassportData>(requestPass);


                if (responsePass.StatusCode == HttpStatusCode.OK)
                {

                    ViewBag.unTravDoc = responsePass.Data.travelDocs;
                    ViewBag.passNum = responsePass.Data.passportNumber;
                    ViewBag.plissue = responsePass.Data.placeOfIssue;
                    ViewBag.dtIsse = responsePass.Data.dateOfIssue;
                    ViewBag.dtExp = responsePass.Data.dateOfExpiry;
                    ViewBag.issuAt = responsePass.Data.issuingAuth;

                }

                //Address & data
                var clientAdDat = new RestClient(urlApiPakistan + "getDataConctact?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestAdDat = new RestRequest(Method.GET);
                var responseAdDat = clientAdDat.Execute<Models.pkContactDetForm>(requestAdDat);


                if (responseAdDat.StatusCode == HttpStatusCode.OK)
                {

                    ViewBag.telHomeA = responseAdDat.Data.telHome;
                    ViewBag.telWorkA = responseAdDat.Data.telWork;
                    ViewBag.telCellA = responseAdDat.Data.telCell;
                    ViewBag.inPakis = responseAdDat.Data.inPakistan;
                    ViewBag.telHomeB = responseAdDat.Data.telHomeB;
                    ViewBag.telWorkB = responseAdDat.Data.telWorkB;
                    ViewBag.telCellB = responseAdDat.Data.telCellB;
                    ViewBag.emailB = responseAdDat.Data.email;
                    ViewBag.bitSporsor = responseAdDat.Data.bitSponsor;

                }

                //Sponsors
                var clientSpon = new RestClient(urlApiPakistan + "getDataSponsors?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestSpon = new RestRequest(Method.GET);
                var responseSpon = clientSpon.Execute<List<Models.pkSponsors>>(requestSpon);

                if (responseSpon.StatusCode == HttpStatusCode.OK)
                {

                    int haveSponsors = responseSpon.Data.Count;

                    if (haveSponsors > 0)
                    {

                        if (haveSponsors == 2)
                        {

                            ViewBag.nameSponsor = responseSpon.Data[0].name;
                            ViewBag.addressSpon = responseSpon.Data[0].address;
                            ViewBag.citySponso = responseSpon.Data[0].city;
                            ViewBag.ZipSpon = responseSpon.Data[0].zipCode;
                            ViewBag.PhoneHome = responseSpon.Data[0].telHome;
                            ViewBag.PhoneWork = responseSpon.Data[0].telWork;
                            ViewBag.CellWork = responseSpon.Data[0].telCell;

                            ViewBag.nameSponsor2 = responseSpon.Data[1].name;
                            ViewBag.addressSpon2 = responseSpon.Data[1].address;
                            ViewBag.citySponso2 = responseSpon.Data[1].city;
                            ViewBag.ZipSpon2 = responseSpon.Data[1].zipCode;
                            ViewBag.PhoneHome2 = responseSpon.Data[1].telHome;
                            ViewBag.PhoneWork2 = responseSpon.Data[1].telWork;
                            ViewBag.CellWork2 = responseSpon.Data[1].telCell;
                        }
                        else
                        {
                            ViewBag.nameSponsor = responseSpon.Data[0].name;
                            ViewBag.addressSpon = responseSpon.Data[0].address;
                            ViewBag.citySponso = responseSpon.Data[0].city;
                            ViewBag.ZipSpon = responseSpon.Data[0].zipCode;
                            ViewBag.PhoneHome = responseSpon.Data[0].telHome;
                            ViewBag.PhoneWork = responseSpon.Data[0].telWork;
                            ViewBag.CellWork = responseSpon.Data[0].telCell;
                        }
                    }

                }



                //Jobs past
                var clientJobs = new RestClient(urlApiPakistan + "getDataJobs?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestJobs = new RestRequest(Method.GET);
                var responseJObs = clientJobs.Execute<Models.pkPastJobs>(requestJobs);

                if (responseJObs.StatusCode == HttpStatusCode.OK)
                {
                    ViewBag.designation = responseJObs.Data.Designation;
                    ViewBag.dept = responseJObs.Data.Depto;
                    ViewBag.durationFrom = responseJObs.Data.DateStart;
                    ViewBag.durationTo = responseJObs.Data.DateFinish;
                    ViewBag.duties = responseJObs.Data.Duties;
                    ViewBag.nameJob = responseJObs.Data.Name;
                    ViewBag.addressJob = responseJObs.Data.Address;
                    ViewBag.phoneJob = responseJObs.Data.Phone;
                    ViewBag.bitApplyVisa = responseJObs.Data.BitApply;
                    ViewBag.descApply = responseJObs.Data.DescAddContr;
                }


                //Family details
                var clientFam = new RestClient(urlApiPakistan + "getDataFamilyDet?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestFam = new RestRequest(Method.GET);
                var responseFam = clientFam.Execute<Models.pkFamilyData>(requestFam);

                if (responseFam.StatusCode == HttpStatusCode.OK)
                {
                    ViewBag.nMother = responseFam.Data.Nmother;
                    ViewBag.nFather = responseFam.Data.Npather;
                    ViewBag.NameSpose = responseFam.Data.SpouseName;
                    ViewBag.dateBirthSpose = responseFam.Data.DateBirth;
                    ViewBag.PlaceBirth = responseFam.Data.PlaceBirth;
                    ViewBag.profesionSpo = responseFam.Data.Profesion;
                    ViewBag.nameEmpSpose = responseFam.Data.NameEmployerSpouse;
                    ViewBag.addSpose = responseFam.Data.AddressEmployerSpouse;
                    ViewBag.telSpose = responseFam.Data.TelEmployerSpouse;
                    ViewBag.bitChildren = responseFam.Data.BitChildrens;
                    ViewBag.bitAccom = responseFam.Data.BitAcompany;
                    ViewBag.bitBank = responseFam.Data.BitAccountBank;
                }


                //Bank Data
                var clientBank = new RestClient(urlApiPakistan + "getDataBank?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestBank = new RestRequest(Method.GET);
                var responseBank = clientBank.Execute<Models.pkBankData>(requestBank);

                if (responseBank.StatusCode == HttpStatusCode.OK)
                {
                    ViewBag.bankName = responseBank.Data.nameBank;
                    ViewBag.branch = responseBank.Data.branch;
                    ViewBag.acNum = responseBank.Data.acNumber;
                    ViewBag.addresBank = responseBank.Data.address;
                    ViewBag.verDet = responseBank.Data.verifierDetails;

                }




                #endregion

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        #region FormPakistanData


        public ActionResult SavePersonalDetPakistan(int idForm, int idVisaAp, int idPurpose, string durationStay, int idVisasTime, int idTypeVisa,
        int idPortsIn, int idPortsOut, string pvPakistan, string dOfProfesion)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SavePersonalDetails");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkPersonalData dataAccount = new Models.pkPersonalData();
            dataAccount.idForm = idForm;
            dataAccount.idVisaAp = idVisaAp;
            dataAccount.idPurpose = idPurpose;
            dataAccount.durationStay = durationStay;
            dataAccount.idVisasTime = idVisasTime;
            dataAccount.idTypeVisa = idTypeVisa;
            dataAccount.idPortIn = idPortsIn;
            dataAccount.idPortOut = idPortsOut;
            dataAccount.pvPakistan = pvPakistan;
            dataAccount.dOfProfesion = dOfProfesion;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Personal data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Personal data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }


        public ActionResult SaveApplicantsDetPakistan(int idForm, string name, string middleName, string lastName, string dateBirth, string cityBirth,
            int idCountry, bool bitSex, bool bitMarital, string bloodGroup, string idMark, string natLanguage, string religion, string natPresent,
            string natPrevious, string natDual)
        {


            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveAppDetails");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkApplicantsData dataAccount = new Models.pkApplicantsData();
            dataAccount.idForm = idForm;
            dataAccount.name = name;
            dataAccount.middleName = middleName;
            dataAccount.lastName = lastName;
            dataAccount.dateBirth = dateBirth;
            dataAccount.cityBirth = cityBirth;
            dataAccount.idCountry = idCountry;
            dataAccount.bitSex = bitSex;
            dataAccount.bitMarital = bitMarital;
            dataAccount.bloodGroup = bloodGroup;
            dataAccount.idMark = idMark;
            dataAccount.natLanguage = natLanguage;
            dataAccount.religion = religion;
            dataAccount.natPresent = natPresent;
            dataAccount.natPrevious = natPrevious;
            dataAccount.natDual = natDual;
            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);

            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;


            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Applicants data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }


            return Json(new { status = true, message = dataMessa, messagePage = "Applicants data saved" });
        }


        public ActionResult SavePassportPakistan(int idForm, int idTypePass, bool bitTravelDocs, string passportNum, string placeIssue, string dateIssue,
                         string dateExpiry, string issueAuht)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SavePassportDetails");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkPassportData dataAccount = new Models.pkPassportData();
            dataAccount.idForm = idForm;
            dataAccount.idTypePass = idTypePass;
            dataAccount.travelDocs = bitTravelDocs;
            dataAccount.passportNumber = passportNum;
            dataAccount.placeOfIssue = placeIssue;
            dataAccount.dateOfIssue = dateIssue;
            dataAccount.dateOfExpiry = dateExpiry;
            dataAccount.issuingAuth = issueAuht;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Passport data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Passport data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public ActionResult SaveConctactDetails(int idForm, int idContry, string telHome, string telWork, string telCell, string inPakistan,
                                                string telHomeb, string telWorkb, string telCellb, string email, bool bitSponsor,
                              string nameSponA, string addSponA, string telHomeSponA, string telWorkSponA, string telCellSponA, string citySponA, string zipCodSponA,
                       bool bitSponsorB, string nameSponB, string addSponB, string telHomeSponB, string telWorkSponB, string telCellSponB, string citySponB, string zipCodSponB)
        {


            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveContactDetails");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkContactData dataAccount = new Models.pkContactData();
            dataAccount.idForm = idForm;
            dataAccount.idCountry = idContry;
            dataAccount.telHome = telHome;
            dataAccount.telWork = telWork;
            dataAccount.telCell = telCell;
            dataAccount.inPakistan = inPakistan;
            dataAccount.telHomeb = telHomeb;
            dataAccount.telWorkb = telWorkb;
            dataAccount.telCellb = telCellb;
            dataAccount.email = email;
            dataAccount.bitSponsor = bitSponsor;
            //Sponsor A
            dataAccount.nameSpon = nameSponA;
            dataAccount.addSponsor = addSponA;
            dataAccount.telHomeSpon = telHomeSponA;
            dataAccount.telWorkSpon = telWorkSponA;
            dataAccount.telCellSpon = telCellSponA;
            dataAccount.citySpon = citySponA;
            dataAccount.zipCodeSpon = zipCodSponA;
            //Sponsor B
            dataAccount.bitSponsorB = bitSponsorB;
            dataAccount.nameSponB = nameSponB;
            dataAccount.addSponsorB = addSponB;
            dataAccount.telHomeSponB = telHomeSponB;
            dataAccount.telWorkSponB = telWorkSponB;
            dataAccount.telCellSponB = telCellSponB;
            dataAccount.citySponB = citySponB;
            dataAccount.zipCodeSponB = zipCodSponB;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Conctact data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }

            return Json(new { status = true, message = dataMessa, messagePage = "Conctact data saved" });
        }


        public ActionResult SavePastJobs(int idForm, string designation, string depto, string dateStart, string dateFinish, string duties, string address,
                                       string phone, string descp, bool bitApply, string name)
        {

            var client = new RestClient("https://localhost:44330/api/Pakistan/SavePastJobs");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkPastJobs dataAccount = new Models.pkPastJobs();
            dataAccount.IdForm = idForm;
            dataAccount.Designation = designation;
            dataAccount.Depto = depto;
            dataAccount.DateStart = dateStart;
            dataAccount.DateFinish = dateFinish;
            dataAccount.Duties = duties;
            dataAccount.Address = address;
            dataAccount.Phone = phone;
            dataAccount.DescAddContr = descp;
            dataAccount.BitApply = bitApply;
            dataAccount.Name = name;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "PastJobs data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }

            return Json(new { status = true, message = dataMessa, messagePage = "PastJobs data saved" });
        }


        public ActionResult SaveFamilyData(int idForm, string nMother, string nFather, int idNatMother, int idNatFather, string spouseName, int idNatSpouse,
                                string dateBirth, string placeBirth, string profesion, bool bitChildrens, string nameEmpSpouse, string addresEmpSpuse, string telEmpSpouse)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveFamilyData");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkFamilyData dataAccount = new Models.pkFamilyData();
            dataAccount.IdForm = idForm;
            dataAccount.Nmother = nMother;
            dataAccount.Npather = nFather;
            dataAccount.IdNatMother = idNatMother;
            dataAccount.IdNatFather = idNatFather;
            dataAccount.SpouseName = spouseName;
            dataAccount.IdNatSpouse = idNatSpouse;
            dataAccount.DateBirth = dateBirth;
            dataAccount.PlaceBirth = placeBirth;
            dataAccount.Profesion = profesion;
            dataAccount.BitChildrens = bitChildrens;
            dataAccount.NameEmployerSpouse = nameEmpSpouse;
            dataAccount.AddressEmployerSpouse = addresEmpSpuse;
            dataAccount.TelEmployerSpouse = telEmpSpouse;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Family data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Family data saved" });
        }


        public JsonResult SaveChildrens([FromBody] List<pkChildrensFamily> model)
        {
            string dataMessa = string.Empty;
            string message = string.Empty;
            if (model.Count > 0)
            {
                var client = new RestClient("https://localhost:44330/api/Pakistan/SaveFamilyChildrens");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.POST);

                List<Models.pkChildrensFamily> dataAccount = new List<Models.pkChildrensFamily>();

                for (int i = 0; i < model.Count; i++)
                {

                    var children = new Models.pkChildrensFamily();

                    children.idForm = model[i].idForm;
                    children.nameChild = model[i].nameChild;
                    children.dateOfBirth = model[i].dateOfBirth;

                    dataAccount.Add(children);
                }

                var jsonForm = JsonConvert.SerializeObject(dataAccount);

                request.AddJsonBody(jsonForm);

                var response = client.Execute(request);
                string content = response.Content.Replace("\"", "");


                if (response.StatusCode == HttpStatusCode.OK)
                {

                    if (content == "OK")
                    {
                        dataMessa = "OK";
                        message = "Family data saved";
                    }
                    else
                    {
                        dataMessa = response.Content;
                    }

                }

            }
            else
            {
                message = "List of childrens not data found";
            }


            return Json(new { status = true, message = dataMessa, messagePage = message });
        }


        public JsonResult SaveAccompanying([FromBody] List<pkFamilySec2> model)
        {

            string dataMessa = string.Empty;
            string message = string.Empty;
            if (model.Count > 0)
            {
                var client = new RestClient("https://localhost:44330/api/Pakistan/SaveFamilyAccomp");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.POST);

                List<Models.pkFamilySec2> dataAccount = new List<Models.pkFamilySec2>();

                for (int i = 0; i < model.Count; i++)
                {

                    var accomp = new Models.pkFamilySec2();

                    accomp.idForm = model[i].idForm;
                    accomp.accompName = model[i].accompName;
                    accomp.dateOfBirth = model[i].dateOfBirth;
                    accomp.passportNumber = model[i].passportNumber;
                    accomp.address = model[i].address;

                    dataAccount.Add(accomp);
                }

                var jsonForm = JsonConvert.SerializeObject(dataAccount);

                request.AddJsonBody(jsonForm);

                var response = client.Execute(request);
                string content = response.Content.Replace("\"", "");


                if (response.StatusCode == HttpStatusCode.OK)
                {

                    if (content == "OK")
                    {
                        dataMessa = "OK";
                        message = "Family Accompanying data saved";
                    }
                    else
                    {
                        dataMessa = response.Content;
                    }

                }
            }
            else
            {
                message = "List of Accompanying not data found";
            }


            return Json(new { status = true, message = dataMessa, messagePage = message });
        }


        public ActionResult SaveBankData(int idForm, string nameBank, string branch, string acNumber, string address, string veriefer)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveFamilyBankData");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkBankData dataAccount = new Models.pkBankData();
            dataAccount.idForm = idForm;
            dataAccount.nameBank = nameBank;
            dataAccount.branch = branch;
            dataAccount.acNumber = acNumber;
            dataAccount.address = address;
            dataAccount.verifierDetails = veriefer;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Bank data saved")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Bank data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public ActionResult SaveBitsTravles(int idForm, bool bitRefused, bool bitRefusedPakistan, bool bitRemoveCountry, bool bitConviction, string detailRefusal)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveTravelData");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkTravelBits dataAccount = new Models.pkTravelBits();
            dataAccount.idForm = idForm;
            dataAccount.bitRefused = bitRefused;
            dataAccount.bitRefusedPakistan = bitRefusedPakistan;
            dataAccount.bitRemoveCountry = bitRemoveCountry;
            dataAccount.bitConviction = bitConviction;
            dataAccount.detailRefusal = detailRefusal;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Travel data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public ActionResult SaveTravelDeported(int idForm, string dateDeport, int idCountry, string reason, string referenceNum)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveTravelDeported");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkDeportedData dataAccount = new Models.pkDeportedData();
            dataAccount.idForm = idForm;
            dataAccount.dateDeport = dateDeport;
            dataAccount.idCountry = idCountry;
            dataAccount.reason = reason;
            dataAccount.referenceNum = referenceNum;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Travel deported data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public ActionResult SaveTravelConviction(int idForm, string dateConviction, int idCountry, string offence, string sentence)
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/SaveTravelConviction");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.pkConvictionData dataAccount = new Models.pkConvictionData();
            dataAccount.idForm = idForm;
            dataAccount.dateConvict = dateConviction;
            dataAccount.idCountry = idCountry;
            dataAccount.offence = offence;
            dataAccount.sentence = sentence;


            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Travel conviction data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public JsonResult SaveTravelLast5([FromBody] List<pkTravelLast5> model)
        {

            string dataMessa = string.Empty;
            string message = string.Empty;
            if (model.Count > 0)
            {
                var client = new RestClient("https://localhost:44330/api/Pakistan/SaveTravel5Years");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.POST);

                List<Models.pkTravelLast5> dataAccount = new List<Models.pkTravelLast5>();

                for (int i = 0; i < model.Count; i++)
                {

                    var travelEn = new Models.pkTravelLast5();

                    travelEn.idForm = model[i].idForm;
                    travelEn.dateTravel = model[i].dateTravel;
                    travelEn.address = model[i].address;
                    travelEn.purpose = model[i].purpose;
                    travelEn.duration = model[i].duration;

                    dataAccount.Add(travelEn);
                }

                var jsonForm = JsonConvert.SerializeObject(dataAccount);

                request.AddJsonBody(jsonForm);

                var response = client.Execute(request);
                string content = response.Content.Replace("\"", "");


                if (response.StatusCode == HttpStatusCode.OK)
                {

                    if (content == "OK")
                    {
                        dataMessa = "OK";
                        message = "Travel visited last 5 years data saved";
                    }
                    else
                    {
                        dataMessa = response.Content;
                    }

                }
            }
            else
            {
                message = "Travel visited last 5 not data found";
            }


            return Json(new { status = true, message = dataMessa, messagePage = message });
        }

        public JsonResult SaveTravelLast2([FromBody] List<pkTravelLast5> model)
        {

            string dataMessa = string.Empty;
            string message = string.Empty;
            if (model.Count > 0)
            {
                var client = new RestClient("https://localhost:44330/api/Pakistan/SaveTravel2Years");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.POST);

                List<Models.pkTravelLast5> dataAccount = new List<Models.pkTravelLast5>();

                for (int i = 0; i < model.Count; i++)
                {

                    var travelEn = new Models.pkTravelLast5();

                    travelEn.idForm = model[i].idForm;
                    travelEn.dateTravel = model[i].dateTravel;
                    travelEn.address = model[i].address;
                    travelEn.purpose = model[i].purpose;
                    travelEn.duration = model[i].duration;

                    dataAccount.Add(travelEn);
                }

                var jsonForm = JsonConvert.SerializeObject(dataAccount);

                request.AddJsonBody(jsonForm);

                var response = client.Execute(request);
                string content = response.Content.Replace("\"", "");


                if (response.StatusCode == HttpStatusCode.OK)
                {

                    if (content == "OK")
                    {
                        dataMessa = "OK";
                        message = "Travel visited last 2 years data saved";
                    }
                    else
                    {
                        dataMessa = response.Content;
                    }

                }
            }
            else
            {
                message = "Travel visited last 2 not data found";
            }


            return Json(new { status = true, message = dataMessa, messagePage = message });
        }

        #endregion


        public IActionResult FormCuba()
        {
            const string urlApiSummary = "https://localhost:44330/api/Cuba/";
            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewBag.Form = HttpContext.Session.GetString("_Form");
            ViewBag.CountryName = HttpContext.Session.GetString("_CountryName");
            ViewData["User"] = ViewBag.Name;
            ViewData["Form"] = ViewBag.Form;
            ViewData["imgForm"] = "/flags/CB.png";

            if (ViewData["User"] != null)
            {

                #region CallContactDetails

                #endregion

                #region CallSummaryData
                //Visa requiered
                var clientContactDet = new RestClient(urlApiSummary + "cdCuIdForm?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.GET);



                var responseCD = clientContactDet.Execute<Models.cuConctacDetails>(request);

                if (responseCD.StatusCode == HttpStatusCode.OK)
                {

                    ViewBag.firstName = responseCD.Data.firstName;
                    ViewBag.surname = responseCD.Data.surName;
                    ViewBag.address = responseCD.Data.address;
                    ViewBag.zipCode = responseCD.Data.zipCode;
                    ViewBag.town = responseCD.Data.town;
                    ViewBag.telNumber = responseCD.Data.telNumber;
                    ViewBag.email = responseCD.Data.emailAddress;

                }

                var clientTrip = new RestClient(urlApiSummary + "tsCuIdForm?idForm=" + ViewData["Form"]);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var requestTrip = new RestRequest(Method.GET);
                var responseTrip = clientTrip.Execute<Models.cuTripShipp>(requestTrip);
                var responseData = JsonConvert.DeserializeObject<Models.cuTripShipp>(responseTrip.Content);

                if (responseTrip.StatusCode == HttpStatusCode.OK)
                {
                    ViewBag.dateEntry = responseData.dateEntryCuba;
                    ViewBag.dateDeparture = responseData.dateDeparture;
                    ViewBag.numAdults = responseData.numsAdults;
                    ViewBag.numChild = responseData.numsChildrens;
                }


                #endregion
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        #region FormCubaData

        public ActionResult SaveConctactDetCuba(int idForm, string firstName, string surName, string address, string zipCode, string town, string emailAddress, string telNum)
        {
            var client = new RestClient("https://localhost:44330/api/Cuba/SaveConctacDetails");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.cuConctacDetails dataAccount = new Models.cuConctacDetails();
            dataAccount.idForm = idForm;
            dataAccount.firstName = firstName;
            dataAccount.surName = surName;
            dataAccount.address = address;
            dataAccount.zipCode = zipCode;
            dataAccount.town = town;
            dataAccount.emailAddress = emailAddress;
            dataAccount.telNumber = telNum;

            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Contact data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public ActionResult SaveTripShippCuba(int idForm, string dateEntry, string dateDeparture, int numAdults, int numChildrens, byte[] passportAdult, byte[] passportChil,
            bool bitShippDifferent, bool bitPPchf5, bool bitRSchf750, bool bitESchf22, bool bitCourrierNatInt)
        {
            var client = new RestClient("https://localhost:44330/api/Cuba/SaveTripShipp");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);


            Models.cuTripShipp dataAccount = new Models.cuTripShipp();
            dataAccount.idForm = idForm;
            dataAccount.dateEntryCuba = dateEntry;
            dataAccount.dateDeparture = dateDeparture;
            dataAccount.numsAdults = numAdults;
            dataAccount.numsChildrens = numChildrens;
            dataAccount.PassportAdult = passportAdult;
            dataAccount.PassportChildren = passportChil;
            dataAccount.bitShippDifferent = bitShippDifferent;
            dataAccount.bitPpchf5 = bitPPchf5;
            dataAccount.bitRschf750 = bitRSchf750;
            dataAccount.bitEschf22 = bitESchf22;
            dataAccount.bitCourierNatInt = bitCourrierNatInt;

            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Trip and Shipp data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public ActionResult SaveSummary(int idForm, string comments, bool bitReadSuccess, bool bitReadGTC)
        {
            var client = new RestClient("https://localhost:44330/api/Cuba/SaveSummary");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.cuSummary dataAccount = new Models.cuSummary();
            dataAccount.IdForm = idForm;
            dataAccount.Comments = comments;
            dataAccount.BitReadSucc = bitReadSuccess;
            dataAccount.BitReadGtc = bitReadGTC;

            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Summary data saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }



        //public ActionResult sendImages(IList<IFormFile> files, int idForm)
        //{

        //    var req = files;

        //    var client = new RestClient("https://localhost:44330/api/Cuba/recieveImagesCuba");
        //    var request = new RestRequest(Method.POST);


        //    byte[] passportAdult = null;
        //    byte[] passportChild = null;


        //    using (var ms = new MemoryStream())
        //    {
        //        files[0].CopyTo(ms);
        //        var fileBytesAd = ms.ToArray();
        //        passportAdult = fileBytesAd;
        //    }

        //    using (var ms = new MemoryStream())
        //    {
        //        files[1].CopyTo(ms);
        //        var fileBytesChi = ms.ToArray();
        //        passportChild = fileBytesChi;
        //    }



        //    //Models.cuSavePassports dataAccount = new Models.cuSavePassports();
        //    //dataAccount.idForm = idForm;
        //    //dataAccount.pasportAdult = passportAdult;
        //    //dataAccount.pasportChild = passportChild;

        //    request.AddHeader("Content-Type", "false");
        //    request.AddHeader("processData", "false");
        //    request.AddFile("files", passportAdult, "passportAdult");
        //    request.AddFile("files", passportChild, "passportChild");
        //    request.AddParameter("idForm", idForm, ParameterType.RequestBody);


        //    //request.AddJsonBody(dataAccount);

                
        //    var response = client.Execute(request);


        //    string content = response.Content.Replace("\"", "");
        //    string dataMessa = string.Empty;

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {

        //        if (content == "OK")
        //        {
        //            dataMessa = "OK";
        //        }
        //        else
        //        {
        //            dataMessa = response.Content;
        //        }

        //    }
        //    return Json(new { status = true, message = "", messagePage = "" });
        //}


        #endregion


        public IActionResult FormSouthKorea()
        {
            const string urlApiSK = "https://localhost:44330/api/SouthKorea/";
            const string urlApiCatalogs = "https://localhost:44330/api/Catalogs/";
            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewBag.Form = HttpContext.Session.GetString("_Form");
            ViewBag.CountryName = HttpContext.Session.GetString("_CountryName");
            ViewData["User"] = ViewBag.Name;
            ViewData["Form"] = ViewBag.Form;
            ViewData["imgForm"] = "/flags/SK.png";

            if (ViewData["User"] != null)
            {
                #region CallCatCountries
                //Visa requiered
                var clientCountry = new RestClient(urlApiCatalogs + "CatCountries");
                var request = new RestRequest(Method.GET);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responseCtry = clientCountry.Execute<List<Models.CatCountries>>(request);
                ViewBag.itemsCountries = responseCtry.Data;
                #endregion

                #region CatPurposes
                //Visa requiered
                var clientPurpose = new RestClient(urlApiCatalogs + "CatPurposes");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                int idCountrySK = 3;
                var responsePurpose = clientPurpose.Execute<List<Models.CatPurposes>>(request);
                ViewBag.itemsPurposes = responsePurpose.Data.Where(x=>x.IdCountry == idCountrySK);
                #endregion


                #region getDataForm
                var clientpi = new RestClient(urlApiSK + "getDataPersonalInfo?idForm=" + ViewData["Form"]);
                var requestpi = new RestRequest(Method.GET);
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responsepi = clientpi.Execute<Models.skPersonalInfo>(requestpi);

                if (responsepi.StatusCode == HttpStatusCode.OK)
                {

                    ViewBag.nameSK = responsepi.Data.NamePassport;
                    ViewBag.IdCountrySK = responsepi.Data.IdCountry;
                    ViewBag.surNameSK = responsepi.Data.Surname;
                    ViewBag.bitSex = responsepi.Data.BitSex;
                    ViewBag.bitNameUk = responsepi.Data.BitNameUknown;
                    ViewBag.bitSurNameUk = responsepi.Data.BitSurNamUknown;
                    ViewBag.passNumSK = responsepi.Data.PassportNum;
                    ViewBag.dateBirthSK = responsepi.Data.DateBirth;
                    ViewBag.dateExpSK = responsepi.Data.DateExpiredPassport;

                }


                #endregion

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


            return View();
    }


        public ActionResult SavePersonalInfo(int idForm, int idCountry, string name, string surName, bool bitSex, bool BitNameUk,
                                                    bool bitSurNamUk, string passNum, string dateBirth, string dateExpired)
        {
            var client = new RestClient("https://localhost:44330/api/SouthKorea/SavePersonalInfo");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.skPersonalInfo pi = new Models.skPersonalInfo();
            pi.IdForm = idForm;
            pi.IdCountry = idCountry;
            pi.NamePassport = name;
            pi.BitSex = bitSex;
            pi.BitNameUknown = BitNameUk;
            pi.Surname = surName;
            pi.BitSurNamUknown = bitSurNamUk;
            pi.PassportNum = passNum;
            pi.DateBirth = dateBirth;
            pi.DateExpiredPassport = dateExpired;

            request.AddJsonBody(pi);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Personal Info saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }



        public ActionResult SaveInformationReq(int idForm, bool bitOtherNat, string mobileNumber, bool bitVisitedKorea, int idCountry, string postalCode,
                                                    string addressPostal, string numberContactKorea, int IdJob, bool BitInfectiuos15, bool BitArrested, string sponsorName,
                                                    string addressNumber, string zipCode, string city, int IdPurposeSK)
        {
            var client = new RestClient("https://localhost:44330/api/SouthKorea/SaveInfoReq");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.skInformationReq pi = new Models.skInformationReq();
            pi.IdForm = idForm;
            pi.BitOtherNat = bitOtherNat;
            pi.MobileNumber = mobileNumber;
            pi.BitVisitedKorea = bitVisitedKorea;
            pi.IdCountry = idCountry;
            pi.PostalCode = postalCode;
            pi.AddressPostal = addressPostal;
            pi.NumberContactKorea = numberContactKorea;
            pi.IdJob = IdJob;
            pi.BitInfectiuos15 = BitInfectiuos15;
            pi.BitArrested = BitArrested;
            pi.SponsorName = sponsorName;
            pi.AddressNumber = addressNumber;
            pi.ZipCode = zipCode;
            pi.City = city;
            pi.IdPurpose = IdPurposeSK;

            request.AddJsonBody(pi);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "OK")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Info Required saved" });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }

        public IActionResult catTypeVisasApplied()
        {
            var client = new RestClient("https://localhost:44330/api/Pakistan/CatVisasApplied");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute<List<Models.CatVisasApplied>>(request);

            ViewBag.items = response.Data;
            return View(response.Data);
        }


    }
}
