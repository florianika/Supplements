﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupplementApi.Models;

namespace SupplementApi.Controllers
{
    public class ProductsController : Controller
    {
        private SupplementModel db = new SupplementModel();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.DietaryClaim).Include(p => p.Producer1).Include(p => p.ProductType).Include(p => p.SupplementForm).Include(p => p.TargetGroup);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.DietaryClaimId = new SelectList(db.DietaryClaims, "Id", "Name");
            ViewBag.Producer = new SelectList(db.Producers, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.ProductTypes, "Id", "Name");
            ViewBag.SupplementFormId = new SelectList(db.SupplementForms, "Id", "Name");
            ViewBag.TargetGroupId = new SelectList(db.TargetGroups, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Producer,TypeId,SupplementFormId,TargetGroupId,DietaryClaimId,Priority")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DietaryClaimId = new SelectList(db.DietaryClaims, "Id", "Name", product.DietaryClaimId);
            ViewBag.Producer = new SelectList(db.Producers, "Id", "Name", product.Producer);
            ViewBag.TypeId = new SelectList(db.ProductTypes, "Id", "Name", product.TypeId);
            ViewBag.SupplementFormId = new SelectList(db.SupplementForms, "Id", "Name", product.SupplementFormId);
            ViewBag.TargetGroupId = new SelectList(db.TargetGroups, "Id", "Name", product.TargetGroupId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.DietaryClaimId = new SelectList(db.DietaryClaims, "Id", "Name", product.DietaryClaimId);
            ViewBag.Producer = new SelectList(db.Producers, "Id", "Name", product.Producer);
            ViewBag.TypeId = new SelectList(db.ProductTypes, "Id", "Name", product.TypeId);
            ViewBag.SupplementFormId = new SelectList(db.SupplementForms, "Id", "Name", product.SupplementFormId);
            ViewBag.TargetGroupId = new SelectList(db.TargetGroups, "Id", "Name", product.TargetGroupId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Producer,TypeId,SupplementFormId,TargetGroupId,DietaryClaimId,Priority")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DietaryClaimId = new SelectList(db.DietaryClaims, "Id", "Name", product.DietaryClaimId);
            ViewBag.Producer = new SelectList(db.Producers, "Id", "Name", product.Producer);
            ViewBag.TypeId = new SelectList(db.ProductTypes, "Id", "Name", product.TypeId);
            ViewBag.SupplementFormId = new SelectList(db.SupplementForms, "Id", "Name", product.SupplementFormId);
            ViewBag.TargetGroupId = new SelectList(db.TargetGroups, "Id", "Name", product.TargetGroupId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
