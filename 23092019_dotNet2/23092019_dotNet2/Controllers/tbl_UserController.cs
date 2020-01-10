using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using PagedList;
using System.Web;
using System.Web.Mvc;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class tbl_UserController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_User
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo id mới có thể phân trang.


            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            //var tbl_User = db.tbl_User.Include(t => t.tbl_Group).Include(t => t.tbl_Group1);
            var tbl_User = db.tbl_User.Include(t => t.tbl_Group).Include(t => t.tbl_Group1).OrderBy(x => x.id);
            //return View(tbl_User.ToList());
            return View(tbl_User.ToPagedList(pageNumber, pageSize));
        }

        // GET: tbl_User/Details/5
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

        // GET: tbl_User/Create
        public ActionResult Create()
        {
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name");
            ViewBag.departmentId = new SelectList(db.tbl_Group, "id", "name");
            return View();
        }

        // POST: tbl_User/Create
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

        // GET: tbl_User/Edit/5
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

        // POST: tbl_User/Edit/5
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

        // GET: tbl_User/Delete/5
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

        // POST: tbl_User/Delete/5
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
