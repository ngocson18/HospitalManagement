using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class SearchUserController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: SearchUser
        public ActionResult Index(string searchString)
        {
            var links = from l in db.tbl_User // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.name.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            return View(links); //trả về kết quả
        }

        // GET: SearchUser/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = db.tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        // GET: SearchUser/Create
        public ActionResult Create()
        {
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name");
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name");
            return View();
        }

        // POST: SearchUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,username,password,dob,departmentId,gender,phone,groupId,groupName,email,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_User tbl_User)
        {
            if (ModelState.IsValid)
            {
                db.tbl_User.Add(tbl_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name", tbl_User.departmentId);
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name", tbl_User.departmentId);
            return View(tbl_User);
        }

        // GET: SearchUser/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = db.tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name", tbl_User.departmentId);
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name", tbl_User.departmentId);
            return View(tbl_User);
        }

        // POST: SearchUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,username,password,dob,departmentId,gender,phone,groupId,groupName,email,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_User tbl_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name", tbl_User.departmentId);
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name", tbl_User.departmentId);
            return View(tbl_User);
        }

        // GET: SearchUser/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = db.tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        // POST: SearchUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_User tbl_User = db.tbl_User.Find(id);
            db.tbl_User.Remove(tbl_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
