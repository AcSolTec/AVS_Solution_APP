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


        #region FormPakistan


        public IActionResult FormPakistan()
        {
            const string urlApiPakistan = "https://localhost:44330/api/Pakistan/";
            const string urlApiCatalogs = "https://localhost:44330/api/Catalogs/";

            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewBag.Form = HttpContext.Session.GetString("_Form");
            ViewData["User"] = ViewBag.Name;
            ViewData["Form"] = ViewBag.Form;


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
                ViewBag.itemsPurposes = responsePurpose.Data;
                #endregion

                #region CallCatPortsInOut
                //Visa requiered
                var clientPortsInOut = new RestClient(urlApiCatalogs + "CatPortsInOut");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var responsePortsInOut = clientPortsInOut.Execute<List<Models.CatsPortsInOut>>(request);
                ViewBag.itemsPorts = responsePortsInOut.Data;
                #endregion

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

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
                              string nameSponA, string addSponA,  string telHomeSponA, string telWorkSponA, string telCellSponA, string citySponA, string zipCodSponA,
                       bool bitSponsorB,  string nameSponB, string addSponB,  string telHomeSponB, string telWorkSponB, string telCellSponB, string citySponB, string zipCodSponB)
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

        #endregion


        public IActionResult FormCuba()
        {
            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewBag.Form = HttpContext.Session.GetString("_Form");
            ViewData["User"] = ViewBag.Name;
            ViewData["Form"] = ViewBag.Form;

            return View();
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
