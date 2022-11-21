using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using weddingWebapp.Models;
using weddingWebapp.Helpers;


//using MailKit.Net.Smtp;
//using MimeKit;
using Microsoft.AspNetCore.Hosting.Server;
using System.Security.Cryptography;
//using MailKit.Security;



using System.Net.Mail;  // g(old)
using weddingWebapp.DataAccess.DataObjects;
using System.Xml.Linq;

namespace weddingWebapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HelperMail helpermail;


        public HomeController(ILogger<HomeController> logger, HelperMail helpermail)
            
        {
            _logger = logger;
            this.helpermail = helpermail;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Regalos()
        {
            return View();
        }

        public IActionResult Ubicacion()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Email()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Login(loginmodel aux)  //laziest login i have ever made.
        {
            if (ModelState.IsValid)
            {
                if (aux.username == "mantenedorRegalos" && aux.password == "SecurePassword.123")
                {
                    return RedirectToAction("Index", "Regaloes");
                }
                
            }
            return RedirectToAction("index");


        }





        public IActionResult Regalo()
        {
            string opcion = HttpContext.Request.Query["opcion"].ToString();
            if (opcion == "1") {
                ViewBag.titulo_producto = "Desayuno en luna de miel";
                ViewBag.descripcion_producto = "Un desayuno romantico en nuestra luna de miel";
                ViewBag.costo = "30000"; //Remember to parse into a number
                ViewBag.rutaImagen = "/img/regalos/desayuno.bmp";
            }
            if (opcion == "2") {
                ViewBag.titulo_producto = "Experiencia Outdoor";
                ViewBag.descripcion_producto = "Experiencia al aire libre en nuestra luna de miel";
                ViewBag.costo = "50000"; //Remember to parse into a number
                ViewBag.rutaImagen = "/img/regalos/ExperienciaOutdoor.png";
            }
            if (opcion == "3")
            {
                ViewBag.titulo_producto = "Dia de Spa";
                ViewBag.descripcion_producto = "Un dia entero dedicado a relajarnos en un Spa. ";
                ViewBag.costo = "60000"; //Remember to parse into a number
                ViewBag.rutaImagen = "/img/regalos/desayuno-luna-de-miel.jpg";
            }
            if (opcion == "4")
            {
                ViewBag.titulo_producto = "Cena romantica";
                ViewBag.descripcion_producto = "Una noche romantica e inolvidable en nuestra luna de miel";
                ViewBag.costo = "80000"; //Remember to parse into a number
                ViewBag.rutaImagen = "/img/regalos/cena romantica.jpg";
            }
            if (opcion == "5")
            {
                ViewBag.titulo_producto = "Noche de hotel";
                ViewBag.descripcion_producto = "Una noche de estadia en un hotel lujoso para nosotros";
                ViewBag.costo = "100000"; //Remember to parse into a number
                ViewBag.rutaImagen = "/img/regalos/hotellunademiel.jpg";
            }


            return View();
        }
 
        [HttpPost]
        public async Task<IActionResult> Regalo(MailModel aux)
        {
            
            //string mensajefinal = "<h1>Proyecto Techclub Tajamar(MVC NetCore Correos)<h1/> <h4>"+aux.Nota.ToString()+"</h4>";

            matrimak_Context modelcontext = new matrimak_Context();

            Regalo regalo = new Regalo();

            regalo.NombreUsuario = aux.Nombre;
            regalo.Notaregalo = aux.Nota;
            regalo.NombreRegalo = "Desayuno luna de miel";
            regalo.Monto = 30000; ///Change as needed on different methods
            
            modelcontext.Add(regalo);
            modelcontext.SaveChanges();

            helpermail.SendMail(aux.Email, "Gracias por tu regalo!", "Muchas gracias por tu regalo! aqui tu mensaje: "+aux.Nota+" para terminar el proceso envianos un mensaje a este correo y depositanos el monto del regalo en" +
                " 003270023807 Cuenta corriente bco chile 17118339-1    RMuencke@hotmail.com  ");
            ViewData["MENSAJE"] = "Mensaje enviado a " + aux.Email.ToString();
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


// matrimak_ db name 

//use something arround the lines of this 
//Scaffold-DbContext "Server=localhost; port=3306;Database=myDataBase;Uid=root;Pwd=1984;" MySql.EntityFrameworkCore -Out Models -force -verbose

