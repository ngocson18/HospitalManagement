using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23092019_dotNet2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Office()
        {
            return View();
        }

        public ActionResult ServiceUnit()
        {
            return View();
        }

        public ActionResult Speciality()
        {
            return View();
        }
    }
}