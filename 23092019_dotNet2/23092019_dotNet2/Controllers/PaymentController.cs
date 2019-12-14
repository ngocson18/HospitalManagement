using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23092019_dotNet2.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentProfile()
        {
            return View();
        }

        public ActionResult DebtList()
        {
            return View();
        }
    }
}