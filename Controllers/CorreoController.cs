using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weddingWebapp.Models;
using weddingWebapp.Helpers;

namespace weddingWebapp.Controllers
{
    public class CorreosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private HelperMail helpermail;
        public CorreosController(HelperMail helpermail)
        {
            this.helpermail = helpermail;
        }



        [HttpPost]
        public IActionResult Index(string receptor, string asunto, string texto)
        {
            string mensajefinal = "<h1>Proyecto Techclub Tajamar(MVC NetCore Correos)<h1/><h4>" + texto + " <h4/>";
            this.helpermail.SendMail(receptor, asunto, mensajefinal);
            ViewData["MENSAJE"] = "Mensaje enviado a '" + receptor + "'";
            return View();
        }
    }
}