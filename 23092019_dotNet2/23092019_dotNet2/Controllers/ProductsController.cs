using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23092019_dotNet2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryProducts()
        {
            return View();
        }

        public ActionResult BuyProducts()
        {
            return View();
        }

        public ActionResult SellProducts()
        {
            return View();
        }

        public ActionResult ProductsList()
        {
            return View();
        }
    }
}