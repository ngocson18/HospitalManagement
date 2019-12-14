using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23092019_dotNet2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserGroup()
        {
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult DoctorList()
        {
            return View();
        }
    }
}