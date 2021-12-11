using AVS_Global.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AVS_Global.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            string urlApiAdmin = _configuration.GetSection("ApiAdmin").Value;
            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewData["User"] = ViewBag.Name;


            if (ViewData["User"] != null)
            {

                var client = new RestClient(urlApiAdmin + "getFormsAuth");
                //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
                var request = new RestRequest(Method.GET);
                var response = client.Execute<List<Models.FormsCap>>(request);
                ViewBag.forms = response.Data;


                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

   
        public ActionResult Auth(int idform)
        {

            string urlApiAdmin = _configuration.GetSection("ApiAdmin").Value;
            //Logic Here change to status 
            var client = new RestClient(urlApiAdmin + "ReviewFormAccepted?idform=" + idform );
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

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

            return RedirectToAction("Index", "Home");
        }

        public IActionResult datatab()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
