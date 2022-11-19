using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using weddingWebapp.Models;

//using MailKit.Net.Smtp;
//using MimeKit;
using Microsoft.AspNetCore.Hosting.Server;
using System.Security.Cryptography;
//using MailKit.Security;



using System.Net.Mail;  // g(old)


namespace weddingWebapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Old()
        {
            return View();
        }



        public IActionResult Regalo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Regalo(MailModel a)
        {
            var smtpClient = new SmtpClient("webmail.matrimakayrai.cl")
            {
                Port = 465,
                Credentials = new System.Net.NetworkCredential("regalos@matrimakayrai.cl", "securepassword123"),
                EnableSsl = false,
            };




            smtpClient.Send("email", "recipient", "subject", "body");


            //FINISH




            return View();

        }
    




        public IActionResult Checkout()
        {
            return View();
        }


        public IActionResult Privacy()
        {
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

