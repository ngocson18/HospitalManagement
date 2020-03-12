using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Controllers
{
    public class tbl_PaymentController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Payment
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
            var tbl_Payment = db.tbl_Payment.Include(t => t.tbl_MedicalBill).OrderBy(x => x.id);
            //return View(tbl_Payment.ToList());
            return View(tbl_Payment.ToPagedList(pageNumber, pageSize));
        }

        // GET: tbl_Payment/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            if (tbl_Payment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment);
        }

        // GET: tbl_Payment/Create
        public ActionResult Create()
        {
            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode");
            return View();
        }

        // POST: tbl_Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,customerName,phone,serviceUnitName,doctor,totalFee,paidFee,debtFee,billId,payTime,status,paymentType,createdTime,updatedTime,createdBy,updatedBy")] tbl_Payment tbl_Payment)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Payment.Add(tbl_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_Payment.billId);
            return View(tbl_Payment);
        }

        // GET: tbl_Payment/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            if (tbl_Payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_Payment.billId);
            //int total = db.tbl_Payment['totalfee'];
            //ViewBag.de = tbl_Payment[totalFee] - tbl_Payment['paidFee'];
            return View(tbl_Payment);
        }

        // POST: tbl_Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,customerName,phone,serviceUnitName,doctor,totalFee,paidFee,debtFee,billId,payTime,status,paymentType,createdTime,updatedTime,createdBy,updatedBy")] tbl_Payment tbl_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.billId = new SelectList(db.tbl_MedicalBill, "id", "billCode", tbl_Payment.billId);
            return View(tbl_Payment);
        }

        // GET: tbl_Payment/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            if (tbl_Payment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Payment);
        }

        // POST: tbl_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_Payment tbl_Payment = db.tbl_Payment.Find(id);
            db.tbl_Payment.Remove(tbl_Payment);
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
