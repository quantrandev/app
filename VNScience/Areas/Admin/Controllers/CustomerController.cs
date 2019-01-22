using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Areas.Admin.DataAccess;
using VNScience.Models;
using VNScience.Models.Core;

namespace VNScience.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        CustomerDAO customerDAO;

        public CustomerController()
        {
            customerDAO = new CustomerDAO(db);
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            var customers = customerDAO.GetAll();

            return View(customers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.OtherCustomers = customerDAO.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Customer model)
        {
            if (!ModelState.IsValid)
                return View();

            //upload file
            var uploadResult = UploadFile(Common.Constants.AdminImagesUrl);
            model.CoverImage = uploadResult.Length == 0 ? "" : uploadResult[0];

            model.CreatedAt = DateTime.Now;
            model.CreatedBy = User.Identity.GetUserId();

            bool isSuccess = customerDAO.Insert(model);

            if (isSuccess)
                Notification.Success("Đã thêm thành công khách hàng mới", Session);
            else
                Notification.Error("Có lỗi xảy ra, vui lòng thử lại sau", Session);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editedCustomer = customerDAO.Get(id);

            ViewBag.OtherCustomers = customerDAO.GetAllExcept(id);
            return View(editedCustomer);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Customer model)
        {
            if (!ModelState.IsValid)
                return View();

            //process file
            if (Request.Files[0].ContentLength > 0)
            {
                var uploadResult = UploadFile(Common.Constants.AdminImagesUrl);
                model.CoverImage = uploadResult.Length == 0 ? "" : uploadResult[0];
            }

            model.UpdatedAt = DateTime.Now;
            model.UpdatedBy = User.Identity.GetUserId();

            bool isSuccess = customerDAO.Update(model);

            if (isSuccess)
                Notification.Success("Đã cập nhật thành công thông tin khách hàng", Session);
            else
                Notification.Error("Có lỗi xảy ra, vui lòng thử lại sau", Session);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isSuccess = customerDAO.Delete(id);

            return Json(new { status = isSuccess ? 200 : 500 }, JsonRequestBehavior.AllowGet);
        }
    }
}