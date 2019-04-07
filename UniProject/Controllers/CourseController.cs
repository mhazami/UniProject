using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.AppCode;
using UniProject.BLL;
using UniProject.DTO;
using static UniProject.DTO.Tools.Enums;

namespace UniProject.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Course
        public ActionResult Index()
        {
            ViewBag.Course = new SelectList(new CategoryBO().GetAll(), "Id", "Title");
            return View();
        }

        public ActionResult GetCourse(int? id)
        {
            try
            {
                if (id.HasValue && id > 0)
                {
                    var course = new CourseBO().Where(c => c.CategoryId == id);
                    return PartialView("PVCourse", course);
                }
                return PartialView("PVCourse", new List<Course>());

            }
            catch (Exception ex)
            {
                ShowMessage("خطا در بازیابی اطلاعات", MessageType.Error);
                return PartialView("PVCourse", new List<Course>());
            }

        }

        public ActionResult GetDes(int id)
        {
            var course = new CourseBO().Get(id);
            return PartialView("PVGetDes", course);
        }
    }
}