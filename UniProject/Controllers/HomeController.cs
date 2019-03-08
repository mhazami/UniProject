using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Header()
        {
            return PartialView("PVHeader");
        }

        public ActionResult Slider()
        {
            return PartialView("PVSlider");
        }
    }
}