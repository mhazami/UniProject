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
    public class UniCourseController : BaseController
    {
        // GET: Admin/UniCourse
        public ActionResult Index()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            var list = new CourseBO().GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            ViewBag.Category = new SelectList(new CategoryBO().GetAll(), "Id", "Title", "");
            ViewBag.Teacher = new SelectList(new TeacherBO().GetAll(), "Id", "LastName", "");
            return View(new Course());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Course course)
        {
            try
            {
                if (!new CourseBO().Insert(course))
                {
                    ShowMessage("خطا در ذخیره سازی اطلاعات", MessageType.Error);
                    return View(course);
                }
                ShowMessage("اطلاعات مورد نظر با موفیت ثبت شد", MessageType.Success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(course);
            }
        }

        public ActionResult Edit(int id)
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            var course = new CourseBO().Get(id);
            var category = new CategoryBO().Get(course.CategoryId);
            ViewBag.Category = new SelectList(new CategoryBO().GetAll(), "Id", "Title", category.Title);
            ViewBag.Teacher = new SelectList(new TeacherBO().GetAll(), "Id", "LastName", new TeacherBO().Get(course.TeacherId).LastName);

            return View(course);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Course course)
        {
            try
            {
                if (!new CourseBO().Update(course))
                {
                    ShowMessage("خطا در ذخیره سازی اطلاعات", MessageType.Error);
                    return View(course);
                }
                ShowMessage("اطلاعات مورد نظر با موفیت ثبت شد", MessageType.Success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(course);
            }
        }
    }
}