using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNScience.Models;

namespace VNScience.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.Customers.OrderBy(e => e.DisplayOrder).ToList();
            return View(customers);
        }
    }
}