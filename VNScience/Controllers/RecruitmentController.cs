using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Models;
using PagedList;
using VNScience.Areas.Admin.DataAccess;

namespace VNScience.Controllers
{
    public class RecruitmentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        SystemInfoDAO systemInfoDAO;
        public RecruitmentController()
        {
            systemInfoDAO = new SystemInfoDAO(db);
        }
        // GET: Recruitment
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var recruitments = db.Recruitments.OrderByDescending(e => e.CreatedAt).ToList();
            return View(recruitments.ToPagedList(page, pageSize));
        }

        public ActionResult Detail(int id)
        {
            var recruitment = db.Recruitments.Find(id);
            ViewBag.RecruitmentInfo = systemInfoDAO.GetRecruitmentInfo();
            return View(recruitment);
        }
    }
}