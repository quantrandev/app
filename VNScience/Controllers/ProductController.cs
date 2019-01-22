using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Models;
using System.Data.Entity;

namespace VNScience.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index(int id)
        {
            var products = db.ProductCategories
                .Include(e => e.Children)
                .FirstOrDefault(e => e.Id == id);

            if(products.Children.Count > 0)
            {
                return View("ProductChildren", products);    
            }

            return View("Index", products);
        }

        [HttpGet]
        public ActionResult Search(string searchString)
        {
            ViewBag.Products = db.ProductCategories
                .Where(e => e.Description.Contains(searchString)
                || e.Name.Contains(searchString))
                .ToList();

            ViewBag.News = db.Posts
                .Where(e => e.Content.Contains(searchString)
                || e.Title.Contains(searchString))
                .ToList();

            ViewBag.SearchString = searchString;
            return View();
        }
    }
}