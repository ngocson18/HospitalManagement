using _23092019_dotNet2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Configuration;
using System.Data;

namespace _23092019_dotNet2.Controllers
{
    public class HomeController : Controller
    {
        private DB_Hospital db = new DB_Hospital();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        //GET: User
        [HttpGet]
        public ActionResult Index()
        {
            int count_all_customer = db.tbl_Customer.Count();
            int count_treatment = db.tbl_Customer.Where(c => c.status == 3).Count();
            int count_done = db.tbl_Customer.Where(c => c.status == 4).Count();
            int count_miss = db.tbl_Customer.Where(c => c.status == 2).Count();
            int count_debt = db.tbl_Payment.Where(c => c.debtFee == 0).Count();
            ViewBag.all_customer = count_all_customer;
            ViewBag.treatment = count_treatment;
            ViewBag.done = count_done;
            ViewBag.miss = count_miss;
            ViewBag.debt = count_debt;
            return View(); 
        }

        void connectionString()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Hospital2"].ConnectionString;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(User user)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select username, password from tbl_User where username = '"+ user.username +"' and password = '"+ user.password +"' ";
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Index");
            }
            else
            {
                con.Close();
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                connectionString();
                con.Open();
                cmd.CommandText = "INSERT INTO tbl_User (name, username, password, phone, departmentId, email)" +
                                    " VALUES(@name, @username, @password, @phone, @departmentId, @email)";
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                //cmd.Parameters.AddWithValue("@dob", user.dob);
                //cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@phone", user.phone);
                cmd.Parameters.AddWithValue("@departmentId", user.departmentId);
                cmd.Parameters.AddWithValue("@email", user.email);
                //cmd.Parameters.AddWithValue("@status", 1);
                //cmd.Parameters.AddWithValue("@createdTime", new DateTime());
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                return View("Login");
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return View("Register");
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}