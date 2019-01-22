using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Areas.Admin.DataAccess;
using VNScience.DataAccess;
using VNScience.Models;

namespace VNScience.Controllers
{
    public class CommonController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ClientPostDAO postDAO;
        SystemInfoDAO systemInfoDAO;
        MenuDAO menuDAO;
        ProductCategoryDAO productCategoryDAO;
        RecruitmentDAO recruitmentDAO;

        public CommonController()
        {
            productCategoryDAO = new ProductCategoryDAO(db);
            menuDAO = new MenuDAO(db);
            postDAO = new ClientPostDAO(db);
            systemInfoDAO = new SystemInfoDAO(db);
            recruitmentDAO = new RecruitmentDAO(db);
        }

        public PartialViewResult Header()
        {
            ViewBag.Logo = systemInfoDAO.GetLogo();
            ViewBag.TopMenus = menuDAO.GetTopMenus();
            ViewBag.Categories = productCategoryDAO.GetAll();
            ViewBag.SocialLinks = systemInfoDAO.GetSocialLink();
            return PartialView("Header");
        }

        public PartialViewResult Footer()
        {
            ViewBag.Brand = systemInfoDAO.GetBrand();
            ViewBag.Logo = systemInfoDAO.GetLogo();
            ViewBag.BottomMenus = menuDAO.GetBottomMenus();
            ViewBag.ContactInfo = systemInfoDAO.GetContactInfo();
            ViewBag.SocialLinks = systemInfoDAO.GetSocialLink();
            ViewBag.HotNews = postDAO.GetAll(1, 10).Skip(0).Take(6).ToList();
            ViewBag.ContactInfo = systemInfoDAO.GetContactInfo();
            ViewBag.Recruitments = recruitmentDAO.GetAllWithUser().Skip(0).Take(3).ToList();
            return PartialView("Footer");
        }

        public PartialViewResult RightCol()
        {
            return PartialView("RightCol");
        }
    }
}