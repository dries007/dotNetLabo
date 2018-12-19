using System;
using System.Diagnostics;
using LaboDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(int klantnr)
        {
            if (Request.Method == "POST")
            {
                Console.WriteLine("Login " + klantnr);

                var r = Klanten.instance.Select(klantnr);
                
                Console.WriteLine(r);
                
                if (r == null) return RedirectToAction("Index");

                _session.SetString("KlantNaam", r["naam"].ToString());
                _session.SetInt32("KlantNr", (int)r["nr"]);
                
                return RedirectToAction("Klant");
            }
            else
            {
                return RedirectToAction("Index");    
            }
        }

        public IActionResult Registreer(string naam, string adress)
        {
            if (Request.Method == "POST")
            {
                Console.WriteLine("Registreer " + naam, adress);

                var r = Klanten.instance.Add(naam, adress);
                
                Console.WriteLine(r);
                
                if (r == null) return RedirectToAction("Index");

                _session.SetString("KlantNaam", r["naam"].ToString());
                _session.SetInt32("KlantNr", (int)r["nr"]);
                
                return RedirectToAction("Klant");
            }
            else
            {
                return RedirectToAction("Index");    
            }
        }
        
        public IActionResult Klant()
        {
            ViewData["reservaties"] = Reservaties.instance.SelectByKlant(_session.GetInt32("KlantNr").Value);
            return View();
        }

        public IActionResult Reserveer()
        {
            ViewData["locaties"] = Locatie.Locaties;
            ViewData["autos"] = Auto.Autos;
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