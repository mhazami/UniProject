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
    public class UniCategoryController : BaseController
    {
        // GET: Admin/UniCategory
        public ActionResult Index()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            var list = new CategoryBO().GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (!new CategoryBO().Insert(category))
                {
                    ShowMessage("خطا در ذخیره سازی اطلاعات", MessageType.Error);
                    return View(category);
                }
                ShowMessage("اطلاعات مورد نظر با موفیت ثبت شد", MessageType.Success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(category);
            }
        }

        public ActionResult Edit(int id)
        {
            if (SessionParameters.User == null)
                return Redirect("~/Admin/User/Login");
            var category = new CategoryBO().Get(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (!new CategoryBO().Update(category))
                {
                    ShowMessage("خطا در ذخیره سازی اطلاعات", MessageType.Error);
                    return View(category);
                }
                ShowMessage("اطلاعات مورد نظر با موفیت ثبت شد", MessageType.Success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(category);
            }
        }
    }
}