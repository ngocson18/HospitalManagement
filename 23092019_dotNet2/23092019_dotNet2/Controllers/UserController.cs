using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using System.Data;

using System.Data.SqlClient;

using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        SqlConnection conn;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserGroup()
        {
            List<GroupUser> grList = new List<GroupUser>() {
                new GroupUser() {id = "1", name = "Bác sĩ", description = "Nhóm gồm các bác sĩ", status = "1"},
                new GroupUser() {id = "2", name = "Y tá", description = "Nhóm gồm các y tá", status = "0"}
            };
            return View(grList);
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