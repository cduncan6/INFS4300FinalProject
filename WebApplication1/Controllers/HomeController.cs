using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A brief history of IT Services Inc.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to contact us.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "List of services provided.";

            return View();
        }
        public ActionResult Team()
        {
            ViewBag.Message = "Meet our Team!";

            return View();
        }
    }
}