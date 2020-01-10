using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using PagedList;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class tbl_DoneController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Done
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
            var tbl_Customer = db.tbl_Customer.Where(t => t.status == 4).Include(t => t.tbl_Office).Include(t => t.tbl_ServiceUnit).OrderBy(x => x.id);
            //return View(tbl_Customer.ToList());
            return View(tbl_Customer.ToPagedList(pageNumber, pageSize));
        }

        // GET: tbl_Done/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // GET: tbl_Done/Create
        public ActionResult Create()
        {
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name");
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name");
            return View();
        }

        // POST: tbl_Done/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,dob,gender,phone,userName,userId,avatar,facebook,customerType,serviceUnitId,serviceUnitName,quantity,bookingDate,comingDate,reappointmentDate,doctor,officeId,officeName,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Customer.Add(tbl_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_Customer.officeId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_Customer.serviceUnitId);
            return View(tbl_Customer);
        }

        // GET: tbl_Done/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_Customer.officeId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_Customer.serviceUnitId);
            return View(tbl_Customer);
        }

        // POST: tbl_Done/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,dob,gender,phone,userName,userId,avatar,facebook,customerType,serviceUnitId,serviceUnitName,quantity,bookingDate,comingDate,reappointmentDate,doctor,officeId,officeName,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.officeId = new SelectList(db.tbl_Office, "id", "name", tbl_Customer.officeId);
            ViewBag.serviceUnitId = new SelectList(db.tbl_ServiceUnit, "id", "name", tbl_Customer.serviceUnitId);
            return View(tbl_Customer);
        }

        // GET: tbl_Done/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // POST: tbl_Done/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            db.tbl_Customer.Remove(tbl_Customer);
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
