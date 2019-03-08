using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.BLL;

namespace UniProject.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            List<DTO.Course> list = new CourseBO().GetAll();
            return View(list);
        }
    }
}