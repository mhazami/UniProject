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
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Student student)
        {
            try
            {
                Student res = new StudentBO().Loging(student);
                if (res != null)
                {
                    SessionParameters.Student = res;
                    return Redirect("~/Course/Index");
                }
                ShowMessage("نام کاربری یا رمز عبور اشتباه میباشد", MessageType.Error);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            try
            {
                if (!new StudentBO().Insert(student))
                {
                    ShowMessage("خطا در ورود اطلاعات", MessageType.Error);
                }
                ShowMessage("اطلاعات کاربر جدید با موفقیت ثبت شد", MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }

            return View(User);
        }

        public ActionResult Loguot()
        {
            SessionParameters.Student = null;
            return Redirect("~/Student/Login");
        }
    }
}