using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System.Net;

namespace AVS_Global.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
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
            if (response.StatusCode == HttpStatusCode.OK)
            {

                if (content == "Login Successfull!")
                {
                    dataMessa = "OK";
                }
                else
                {
                    dataMessa = response.Content;
                }

            }
            return Json(new { status = true, message = dataMessa });
            //ResponseApiClubPremier responseAPICP = new JsonDeserializer().Deserialize<ResponseApiClubPremier>(response);
        }
    }
}
