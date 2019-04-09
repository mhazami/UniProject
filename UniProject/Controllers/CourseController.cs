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
                ShowMessage(ex.Message, MessageType.Error);
                return PartialView("PVCourse", new List<Course>());
            }

        }

        public ActionResult GetDes(int id)
        {
            var course = new CourseBO().Get(id);
            return PartialView("PVGetDes", course);
        }

        public ActionResult Register(int? id)
        {
            var capacity = new CourseStudentBO().Count(c => c.CourseId == id.Value);
            var course = new CourseBO().Get(id.Value);
            if (course.Capacity <= capacity) return Content("full");
            if (!id.HasValue || id == 0) return Content("false");
            if (SessionParameters.Student == null) return Content("login");
            var stcousre = new CourseStudent()
            {
                StudentId = SessionParameters.Student.Id,
                CourseId = id.Value
            };
            var obj = new CourseStudentBO().FirstOrDefault(c => c.CourseId == id.Value && c.StudentId == SessionParameters.Student.Id);
            if (obj != null) return Content("registered");
            if (!new CourseStudentBO().Insert(stcousre))
            {
                return Content("false");
            }
            if (course.Capacity <= capacity)
            {
                course.Status = CourseStatus.Full;
                new CourseBO().Update(course);
            }
            return Content("true");
        }
    }
}