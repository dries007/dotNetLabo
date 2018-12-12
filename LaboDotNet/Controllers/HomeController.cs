using System;
using System.Diagnostics;
using LaboDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaboDotNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(int klantnr)
        {
            if (Request.Method == "POST")
            {
                Console.WriteLine("Login", klantnr);
                //todo user auth & login, session stuff
                return RedirectToAction("Klant");
            }
            else
            {
                return RedirectToAction("Index");    
            }
        }
        
        public IActionResult Klant()
        {
            return View();
        }

        public IActionResult Reserveer()
        {
            ViewData["locaties"] = Locatie.Locaties;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}