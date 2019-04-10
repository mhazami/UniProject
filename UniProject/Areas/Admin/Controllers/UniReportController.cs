using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.AppCode;
using UniProject.BLL;

namespace UniProject.Areas.Admin.Controllers
{
    public class UniReportController : Controller
    {
        // GET: Admin/UniReport
        public ActionResult Index()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            return View();
        }

        public ActionResult CourseStudent()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            var list = new CourseStudentBO().GetAll();
            return View(list);
        }
    }
}