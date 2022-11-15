using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using weddingWebapp.Models;

using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Hosting.Server;
using System.Security.Cryptography;

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
            MimeMessage message = new MimeMessage();
            BodyBuilder bodyBuilder = new BodyBuilder();
            SmtpClient client = new SmtpClient();


            //basic stuff
            MailboxAddress from = new MailboxAddress("Matrimonio Makarena Raimundo",
            "matrimoniomr@outlook.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(a.Nombre,
            a.Email);
            message.To.Add(to);
            message.Subject = "Mensaje de prueba";


            //actual message
            bodyBuilder.HtmlBody = "<h1>Mensaje de prueba</h1>";
            bodyBuilder.TextBody = a.Nota;

            message.Body = bodyBuilder.ToMessageBody();


            //connection & authentication
            client.Connect("smtp-mail.outlook.com", 587, false); //ssl
            client.Authenticate("matrimoniomr@outlook.com", "securepassword123");


            //sending
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

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

