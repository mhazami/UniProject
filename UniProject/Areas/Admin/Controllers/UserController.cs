﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.AppCode;
using UniProject.BLL;
using UniProject.DTO;
using UniProject.DTO.Tools;

namespace UniProject.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                User res = new UserBO().Loging(user);
                if (res != null)
                {
                    SessionParameters.User = res;
                    return Redirect("~/Admin/Panel/Index");
                }
                ShowMessage("نام کاربری یا رمز عبور اشتباه میباشد", Enums.MessageType.Error);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Enums.MessageType.Error);
            }
            return View();
        }

        public ActionResult Loguot()
        {
            SessionParameters.User = null;
            return Redirect("~/Admin/User/Login");
        }

        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (!new UserBO().Insert(user))
                {
                    ShowMessage("خطا در ورود اطلاعات", Enums.MessageType.Error);
                }
                ShowMessage("اطلاعات کاربر جدید با موفقیت ثبت شد", Enums.MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Enums.MessageType.Error);
            }

            return View(User);
        }
    }
}