using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Areas.Admin.DataAccess;
using VNScience.Common;
using VNScience.DataAccess;
using VNScience.Models;

namespace VNScience.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ClientPostDAO postDAO;

        public HomeController()
        {
            postDAO = new ClientPostDAO(db);
        }

        public ActionResult Index()
        {
            ViewBag.Slides = db.Slides.OrderBy(e => e.DisplayOrder).ToList();
            ViewBag.Products = db.ProductCategories.Where(e=>e.ParentId == null).OrderBy(e => e.DisplayOrder).ToList();
            ViewBag.Posts = db.Posts.OrderByDescending(e => e.CreatedAt)
                .Skip(0)
                .Take(8)
                .ToList();
            ViewBag.Customers = db.Customers.ToList();
            return View();
        }
        
    }
}