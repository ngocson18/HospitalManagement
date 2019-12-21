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
    public class tbl_ProductController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_Product
        public ActionResult Index()
        {
            var tbl_Product = db.tbl_Product.Include(t => t.tbl_ProductCategory);
            return View(tbl_Product.ToList());
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
        public ActionResult Create([Bind(Include = "id,productCode,productName,productCategoryId,productCategoryName,urlImage,priceOne,priceIn,priceOut,quantity,status,supplier,importDate,VAT,createdTime,updatedTime,createdBy,updatedBy")] tbl_Product tbl_Product)
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
