using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Models;
using PagedList;
using System.Data.Entity;

namespace VNScience.Controllers
{
    public class NewsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var news = db.Posts.OrderByDescending(e => e.CreatedAt).ToList();
            return View(news.ToPagedList(page, pageSize));
        }

        public ActionResult Detail(int id)
        {
            var news = db.Posts
                .Include(e => e.Tags)
                .FirstOrDefault(e => e.Id == id);
            return View(news);
        }
    }
}