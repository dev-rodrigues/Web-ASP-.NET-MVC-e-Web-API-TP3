using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var data = new Dictionary<string, string> {
                    { "grant_type", "password" },
                    { "username", model.Username },
                    { "password", model.Password }
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:56435");

                    using (var requestContent = new FormUrlEncodedContent(data))
                    {
                        var response = await client.PostAsync("/Token", requestContent);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();

                            var tokenData = JObject.Parse(responseContent);

                            Session.Add("access_token", tokenData["access_token"]);
                            Session.Add("user_name", model.Username);

                            return RedirectToAction("Index", "Home");
                        }
                        return View("Error");
                    }
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:56435");

                    var response = await client.PostAsJsonAsync("Api/Account/Register", model);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
        
            return View();
        }

    }
}