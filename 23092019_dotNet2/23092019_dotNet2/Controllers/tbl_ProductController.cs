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
    public class tbl_ProductController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Product
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
            var tbl_Product = db.tbl_Product.Include(t => t.tbl_ProductCategory).OrderBy(x => x.id);
            //return View(tbl_Product.ToList());
            return View(tbl_Product.ToPagedList(pageNumber, pageSize));
        }

        // GET: tbl_Product/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // GET: tbl_Product/Create
        public ActionResult Create()
        {
            ViewBag.productCategoryId = new SelectList(db.tbl_ProductCategory, "id", "name");
            return View();
        }

        // POST: tbl_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,productCode,productName,productCategoryId,urlImage,priceOne,priceIn,priceOut,quantity,status,supplier,importDate,VAT,createdTime,updatedTime,createdBy,updatedBy")] tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Product.Add(tbl_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productCategoryId = new SelectList(db.tbl_ProductCategory, "id", "name", tbl_Product.productCategoryId);
            return View(tbl_Product);
        }

        // GET: tbl_Product/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.productCategoryId = new SelectList(db.tbl_ProductCategory, "id", "name", tbl_Product.productCategoryId);
            return View(tbl_Product);
        }

        // POST: tbl_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,productCode,productName,productCategoryId,productCategoryName,urlImage,priceOne,priceIn,priceOut,quantity,status,supplier,importDate,VAT,createdTime,updatedTime,createdBy,updatedBy")] tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productCategoryId = new SelectList(db.tbl_ProductCategory, "id", "name", tbl_Product.productCategoryId);
            return View(tbl_Product);
        }

        // GET: tbl_Product/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // POST: tbl_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            db.tbl_Product.Remove(tbl_Product);
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
