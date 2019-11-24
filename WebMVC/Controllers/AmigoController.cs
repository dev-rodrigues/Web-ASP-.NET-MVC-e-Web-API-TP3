using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AmigoController : Controller
    {
        private string UrlDefault = "http://localhost:55883";


        public async Task<ActionResult> Index ()
        {
            List<InputFriendModel> Amigos = new List<InputFriendModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlDefault);
                var response = await client.GetAsync($"api/friend");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Amigos = JsonConvert.DeserializeObject<List<InputFriendModel>>(responseContent);
                    return View(Amigos);
                }
            }

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
            var access_token = Session["access_token"];

            var data = new Dictionary<string, string>
            {
                { "Nome", amigo.Nome },
                { "Sobrenome", amigo.Sobrenome },
                { "Email", amigo.Email },
                { "Telefone", amigo.Telefone },
                { "Aniversario", amigo.Aniversario }
            };

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(UrlDefault);

                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                using( var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await cliente.PostAsync("/api/friend/create", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
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