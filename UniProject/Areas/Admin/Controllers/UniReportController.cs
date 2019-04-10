using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.AppCode;
using UniProject.BLL;
using UniProject.DTO;
using static UniProject.DTO.Tools.Enums;

namespace UniProject.Areas.Admin.Controllers
{
    public class UniReportController : BaseController
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
            ViewBag.CourseId = new SelectList(new CourseBO().GetAll(), "Id", "Title");
            return View();
        }

        public ActionResult Delete(int stId, int coId)
        {
            var obj = new CourseStudent()
            {
                StudentId = stId,
                CourseId = coId
            };
            new CourseStudentBO().Delete(obj);
            return RedirectToAction("CourseStudent");

        }

        public ActionResult GetReport(int? courseId)
        {
            var list = new CourseStudentBO().Where(c => c.CourseId == courseId);
            return PartialView("PVTableReport", list); 
        }

        public ActionResult StudentReport()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            var list = new StudentBO().GetAll();
            return View(list);
        }
    }
}