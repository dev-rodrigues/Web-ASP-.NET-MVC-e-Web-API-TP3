using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AmigoController : Controller
    {
        private string UrlDefault = "http://localhost:55883";

        public ActionResult Index ()
        {
            List<InputFriendModel> Amigos = new List<InputFriendModel>();
            return View(Amigos);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(InputFriendModel amigo)
        {
            var access_email = Session["user_name"];
            var access_token = Session["access_token"];

            var data = new Dictionary<string, string>
            {
                { "Nome", amigo["Nome"] },
                { "Sobrenome", amigo["Sobrenome"] },
                { "Email", amigo["Email"] },
                { "Telefone", amigo["Telefone"] },
                { "Aniversario", amigo["Aniversario"] }
            };

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(UrlDefault);

                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                using( var requestContent = new FormUrlEncodedContent(data))

                var response = await cliente.PostAsync("/api/friend/create", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                    
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(InputFriendModel amigo)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(InputFriendModel amigo)
        {
            return View();
        }

    }
}