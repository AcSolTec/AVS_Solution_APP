using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Controllers
{
    public class FormulariesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormPakistan()
        {

            const string urlApiPakistan = "https://localhost:44330/api/Pakistan/";

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
            var requestReq = new RestRequest(Method.GET);
            var responseReq = clientReq.Execute<List<Models.CatVisasRequiered>>(request);

            ViewBag.itemsReq = responseReq.Data;
            #endregion

            #region CallCatTypesVisas
            //Visa requiered
            var clientType = new RestClient(urlApiPakistan + "TypesVisas");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var requestType = new RestRequest(Method.GET);
            var responseType = clientType.Execute<List<Models.CatTypeVisas>>(request);

            ViewBag.itemsType = responseType.Data;
            #endregion

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
