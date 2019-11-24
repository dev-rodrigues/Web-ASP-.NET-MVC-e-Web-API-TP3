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
        public ActionResult Create(InputFriendModel amigo)
        {
            return View();
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