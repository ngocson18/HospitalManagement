using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web.Mvc;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class LoginController : Controller
    {
        private DB_Hospital db = new DB_Hospital();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(tbl_User login)
        {
            if(ModelState.IsValid)
            {
                db.tbl_User.Add(login);
                db.SaveChanges();
            }
            return View(login);
        }
    }
}