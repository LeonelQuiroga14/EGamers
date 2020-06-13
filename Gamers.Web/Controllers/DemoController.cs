using Gamers.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamers.Web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Suma() 
        {
            ViewBag.Titulo    = "Leonel Quiroga aguante River";
            ViewData["Fecha"] = DateTime.Now.ToShortDateString();
            return View();
        }
        [HttpPost]
        public ActionResult Suma(int Num1, int Num2)
        {
            var cuenta = new Cuenta(Num1,Num2);   
            return View(cuenta);
        }
    }
}