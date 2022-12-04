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
using System.Security.Policy;

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

            switch (opcion)
            {
                case "1":
                    ViewBag.titulo_producto = "Desayuno en luna de miel";
                    ViewBag.descripcion_producto = "Un desayuno romantico en nuestra luna de miel";
                    ViewBag.costo = 30000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/desayuno.bmp";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "2":
                    ViewBag.titulo_producto = "Experiencia Outdoor";
                    ViewBag.descripcion_producto = "Experiencia al aire libre en nuestra luna de miel";
                    ViewBag.costo = 50000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/ExperienciaOutdoor.png";
                    ViewBag.precioVisible = "d-none";
                    break ;
                case "3":
                    ViewBag.titulo_producto = "Dia de Spa";
                    ViewBag.descripcion_producto = "Un dia entero dedicado a relajarnos en un Spa. ";
                    ViewBag.costo = 60000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/desayuno-luna-de-miel.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "4":
                    ViewBag.titulo_producto = "Cena romantica";
                    ViewBag.descripcion_producto = "Una noche romantica e inolvidable en nuestra luna de miel";
                    ViewBag.costo = 80000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/cena romantica.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "5":
                    ViewBag.titulo_producto = "Noche de hotel";
                    ViewBag.descripcion_producto = "Una noche de estadia en un hotel lujoso para nosotros";
                    ViewBag.costo = 100000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/hotellunademiel.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "6":
                    ViewBag.titulo_producto = "Paisajismo para nuestra casa propia";
                    ViewBag.descripcion_producto = "Aporte para el paisajismo de nuestra casa";
                    ViewBag.costo = 120000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/PaisajismoCasaPropia.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "7":
                    ViewBag.titulo_producto = "Tour de Luna de Miel";
                    ViewBag.descripcion_producto = "un Tour en nuestra luna de miel, para hacer un viaje inolvidable";
                    ViewBag.costo = 130000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/tourlunademiel.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "8":
                    ViewBag.titulo_producto = "Pasajes Luna de miel";
                    ViewBag.descripcion_producto = "Un aporte para nuestros pasajes para un viaje inolvidable";
                    ViewBag.costo = 160000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/PasajesLunaDeMiel.png";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "9":
                    ViewBag.titulo_producto = "Renovacion de muebles para nuestra casa";
                    ViewBag.descripcion_producto = "Un aporte para nuestro muebles de nuestra propia casa";
                    ViewBag.costo = 250000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/renovacionmuebles.jpg";
                    ViewBag.precioVisible = "d-none";
                    break ;
                case "10":
                    ViewBag.titulo_producto = "Aporte de 300000 para nuestra casa";
                    ViewBag.descripcion_producto = "un aporte para lograr nuestra meta de la casa propia";
                    ViewBag.costo = 300000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/aportecasa1.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "11":
                    ViewBag.titulo_producto = "Aporte de 400000 para nuestra casa";
                    ViewBag.descripcion_producto = "un aporte para lograr nuestra meta de la casa propia";
                    ViewBag.costo = 400000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/aportecasa2.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "12":
                    ViewBag.titulo_producto = "Aporte de 500000 para nuestra casa";
                    ViewBag.descripcion_producto = "un aporte para lograr nuestra meta de la casa propia";
                    ViewBag.costo = 500000; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/regalos/aportecasa3.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                case "13":
                    ViewBag.titulo_producto = "El regalo que tu quieras";
                    ViewBag.descripcion_producto = "Danos el regalo que tu quieras y te estaremos agradecidos por ello";
                    ViewBag.costo = 0; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/img-13.jpg";
                    ViewBag.precioVisible = "d-none";
                    break;
                default:
                    ViewBag.titulo_producto = "El regalo que tu quieras";
                    ViewBag.descripcion_producto = "Danos el regalo que tu quieras y te estaremos agradecidos por ello";
                    ViewBag.costo = 0; //Remember to parse into a number
                    ViewBag.rutaImagen = "/img/img-13.jpg";
                    ViewBag.precioVisible = "";
                    break;

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
            regalo.NombreRegalo = aux.NombreRegalo;
            regalo.Monto = aux.Monto;
            regalo.Correo = aux.Email;

            Console.WriteLine(aux.Monto.ToString() + aux.Email + aux.Nombre+ aux.NombreRegalo+ aux.Nota);
            Console.WriteLine(regalo.NombreUsuario+ regalo.NombreRegalo+ regalo.Idregalo+ regalo.Monto+ regalo.Notaregalo+ regalo.Correo);


            modelcontext.Add(regalo);
            modelcontext.SaveChanges();
            
            RedirectToAction("Email");  //aight lets give it a shot


            try
            {
                helpermail.SendMail(aux.Email, "Comprobante de tu regalo", "<h1>Gracias por tu regalo " + aux.Nombre + "! </h1> <p>para terminar el proceso envianos un mensaje a este correo y depositanos el monto del regalo en</p>" +
                " <p>003270023807</p> <p>Cuenta corriente bco chile</p> <p>17118339-1</p>  <p>RMuencke@hotmail.com</p> <p>Recuerda enviarnos tu comprobante de deposito al correo RMuencke@hotmail.com y porsupuesto muchisimas gracias, esperamos verte en nuestra boda. </p> ");
                ViewData["MENSAJE"] = "Mensaje enviado a " + aux.Email.ToString();
                return RedirectToAction("Email");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Email");

            }
            
        }

        public async Task<IActionResult> RegaloLibre()
        {

            ViewBag.descripcion_producto = "Danos el regalo que tu quieras y te estaremos agradecidos por ello";
            ViewBag.costo = 0; //Remember to parse into a number
            ViewBag.rutaImagen = "/img/img-13.jpg";
            ViewBag.precioVisible = "";



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegaloLibre(MailModel aux)
        {
            matrimak_Context modelcontext = new matrimak_Context();

            Regalo regalo = new Regalo();

            regalo.NombreUsuario = aux.Nombre;
            regalo.Notaregalo = aux.Nota;
            regalo.NombreRegalo = aux.NombreRegalo;
            regalo.Monto = aux.Monto;
            regalo.Correo = aux.Email;

            Console.WriteLine(aux.Monto.ToString() + aux.Email + aux.Nombre + aux.NombreRegalo + aux.Nota);
            Console.WriteLine(regalo.NombreUsuario + regalo.NombreRegalo + regalo.Idregalo + regalo.Monto + regalo.Notaregalo + regalo.Correo);


            modelcontext.Add(regalo);
            modelcontext.SaveChanges();

            RedirectToAction("Email");  //aight lets give it a shot


            try
            {
                helpermail.SendMail(aux.Email, "Comprobante de tu regalo", "<h1>Gracias por tu regalo " + aux.Nombre + "! </h1> <p>para terminar el proceso envianos un mensaje a este correo y depositanos el monto del regalo en</p>" +
                " <p>003270023807</p> <p>Cuenta corriente bco chile</p> <p>17118339-1</p>  <p>RMuencke@hotmail.com</p> <p>Recuerda enviarnos tu comprobante de deposito al correo RMuencke@hotmail.com y porsupuesto muchisimas gracias, esperamos verte en nuestra boda. </p> ");
                ViewData["MENSAJE"] = "Mensaje enviado a " + aux.Email.ToString();
                return RedirectToAction("Email");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Email");

            }




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

