using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaTestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var rand = new Random();
            var upperBound = rand.Next(10000000, 20000000);
            var items = new List<string>();
            for(var i = 0; i < upperBound; i++)
            {
                items.Add($"rand.Next(0, 1000)");
            }

            ViewBag.ItemCount = items.Count;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}