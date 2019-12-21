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
    public class tbl_ProductCategoryController : Controller
    {
        private DB_Hospital db = new DB_Hospital();

        // GET: tbl_ProductCategory
        public ActionResult Index()
        {
            return View(db.tbl_ProductCategory.ToList());
        }

        // GET: tbl_ProductCategory/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ProductCategory tbl_ProductCategory = db.tbl_ProductCategory.Find(id);
            if (tbl_ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ProductCategory);
        }

        // GET: tbl_ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,createTime,updatedTime,createdBy,updatedBy")] tbl_ProductCategory tbl_ProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ProductCategory.Add(tbl_ProductCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ProductCategory);
        }

        // GET: tbl_ProductCategory/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ProductCategory tbl_ProductCategory = db.tbl_ProductCategory.Find(id);
            if (tbl_ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ProductCategory);
        }

        // POST: tbl_ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,createTime,updatedTime,createdBy,updatedBy")] tbl_ProductCategory tbl_ProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ProductCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ProductCategory);
        }

        // GET: tbl_ProductCategory/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ProductCategory tbl_ProductCategory = db.tbl_ProductCategory.Find(id);
            if (tbl_ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ProductCategory);
        }

        // POST: tbl_ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_ProductCategory tbl_ProductCategory = db.tbl_ProductCategory.Find(id);
            db.tbl_ProductCategory.Remove(tbl_ProductCategory);
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
