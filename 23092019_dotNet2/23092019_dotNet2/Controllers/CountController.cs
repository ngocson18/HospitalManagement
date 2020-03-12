using _23092019_dotNet2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace _23092019_dotNet2.Controllers
{
    public class CountController : Controller
    {
        private DB_Hospital db = new DB_Hospital();
        // GET: Count
        public ActionResult Index()
        {
            List<tbl_User> data = new List<tbl_User>();
            int count_all_customer = db.tbl_Customer.Count();
            int count_treatment = db.tbl_Customer.Where(c => c.status == 3).Count();
            int count_done = db.tbl_Customer.Where(c => c.status == 4).Count();
            int count_miss = db.tbl_Customer.Where(c => c.status == 2).Count();
            int all_customer = 1000;
            //return View("Index", all_customer);
            return PartialView("~/Views/_Count", all_customer);
        }
    }
}