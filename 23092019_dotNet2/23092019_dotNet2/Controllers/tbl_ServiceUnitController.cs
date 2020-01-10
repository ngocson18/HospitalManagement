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
    public class tbl_ServiceUnitController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_ServiceUnit
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo id mới có thể phân trang.
            var links = (from l in db.tbl_ServiceUnit
                         select l).OrderBy(x => x.id);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            //return View(db.tbl_ServiceUnit.ToList());
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: tbl_ServiceUnit/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            if (tbl_ServiceUnit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceUnit);
        }

        // GET: tbl_ServiceUnit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_ServiceUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,priceVND,priceUSD,note,minPrice,maxPrice,picture,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_ServiceUnit tbl_ServiceUnit)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ServiceUnit.Add(tbl_ServiceUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ServiceUnit);
        }

        // GET: tbl_ServiceUnit/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            if (tbl_ServiceUnit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceUnit);
        }

        // POST: tbl_ServiceUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,priceVND,priceUSD,note,minPrice,maxPrice,picture,status,createdTime,updatedTime,createdBy,updatedBy")] tbl_ServiceUnit tbl_ServiceUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ServiceUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ServiceUnit);
        }

        // GET: tbl_ServiceUnit/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            if (tbl_ServiceUnit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceUnit);
        }

        // POST: tbl_ServiceUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_ServiceUnit tbl_ServiceUnit = db.tbl_ServiceUnit.Find(id);
            db.tbl_ServiceUnit.Remove(tbl_ServiceUnit);
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
