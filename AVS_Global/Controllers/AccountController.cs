﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System.Net;
using RestSharp.Serialization.Json;

namespace AVS_Global.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            const string urlApiCatCustomers = "https://localhost:44330/api/Account/";
            #region CallCatVisasApplied
            var client = new RestClient(urlApiCatCustomers + "CatCountriesCustomer");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute<List<Models.CatCountriesCustomers>>(request);
            ViewBag.items = response.Data;
            #endregion
            return View();
        }


        public ActionResult SaveCustomer(string RegisteredMail, string pass, int IdCountry)
        {
            var client = new RestClient("https://localhost:44330/api/Account/SaveAccount");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.SaveCustomers dataAccount = new Models.SaveCustomers();
            dataAccount.IdCountry = IdCountry;
            dataAccount.RegisteredMail = RegisteredMail;
            dataAccount.Pass = pass;
            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Customer created!")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, messagePage = "Customer created, Please log in with your crendenciales." });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }


        public ActionResult Validate(string user, string pass)
        {
            var client = new RestClient("https://localhost:44330/api/Account");
            //client.Authenticator = new HttpBasicAuthenticator(userApiKey, PassApiKey);
            var request = new RestRequest(Method.POST);

            Models.Accounts dataAccount = new Models.Accounts();
            dataAccount.Mail = user;
            dataAccount.Pass = pass;
            dataAccount.Seed = "";
            request.AddJsonBody(dataAccount);

            var response = client.Execute(request);
            string content = response.Content.Replace("\"", "");
            string dataMessa = string.Empty;
            string countryLogOn = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Models.responseCustomersLog responseAPI = new JsonDeserializer().Deserialize<Models.responseCustomersLog>(response);

                if (responseAPI.loginSuccess)
                {
                    ViewData["User"] = dataAccount.Mail;
                    dataMessa = "OK";
                    countryLogOn = responseAPI.CountryLog.ToString();
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa, countrylog = countryLogOn });
            
        }
    }
}
