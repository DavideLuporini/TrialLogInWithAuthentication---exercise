using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;
using TrialLogInWithAuthentication.Filter;
using TrialLogInWithAuthentication.Models;

namespace TrialLogInWithAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [AuthFilter]
        public IActionResult Index()
        {
            var l = DB.GetTelephones();
            return View(l);
        }

        [AuthFilter]
        public IActionResult Detail(string id)
        {
            var l = DB.GetTelephone(id);
            return View(l);
        }

        public IActionResult Login(bool showerror)
        {
            if (HttpContext.Session.GetString("LogSession") != null)
            {
                return RedirectToAction("Index");
            }
            return View(new LoginUser(showerror));
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            var log = DB.Login(u);
            if (log != null)
            {
                HttpContext.Session.SetString("LogSession", log);
            }
            else
            {
                HttpContext.Session.Remove("LogSession");
                return RedirectToAction("Login", new { showerror = true });
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [AuthFilter]
        public IActionResult BuyTelephone()
        {
            //var l = DB.GetLibroByName(libro.Titolo);
            //if (l != null)
            //{
            //    // alert?
            //}
            //else
            //{
            //    // alert?
            //}
            return RedirectToAction("ShopSuccess");
        }

        [AuthFilter]
        public IActionResult ShopSuccess()
        {
            return View();
        }
    }
}