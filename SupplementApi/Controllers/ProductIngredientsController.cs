using System;
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
    public class ProductIngredientsController : Controller
    {
        private SupplementModel db = new SupplementModel();

        // GET: ProductIngredients/1
        public ActionResult Index(int id)
        {
            var productIngredients = db.ProductIngredients.Include(p => p.Ingredient).Include(p => p.Product).Include(p => p.Unit1).Where(p=> p.IdProduct == id);
            return View(productIngredients.ToList());
        }

        // GET: ProductIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            return View(productIngredient);
        }

        // GET: ProductIngredients/Create
        public ActionResult Create(int id)
        {
            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name");
            ViewBag.IdProduct = new SelectList(db.Products.Where(p => p.Id == id), "Id", "Name");
            ViewBag.Unit = new SelectList(db.Units, "Id", "Name");
            return View();
        }

        // POST: ProductIngredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,IdIngredient,Unit,Value")] ProductIngredient productIngredient)
        {
            if (ModelState.IsValid)
            {
                db.ProductIngredients.Add(productIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient);
            ViewBag.IdProduct = new SelectList(db.Products, "Id", "Name", productIngredient.IdProduct);
            ViewBag.Unit = new SelectList(db.Units, "Id", "Name", productIngredient.Unit);
            return View(productIngredient);
        }

        // GET: ProductIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient);
            ViewBag.IdProduct = new SelectList(db.Products, "Id", "Name", productIngredient.IdProduct);
            ViewBag.Unit = new SelectList(db.Units, "Id", "Name", productIngredient.Unit);
            return View(productIngredient);
        }

        // POST: ProductIngredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,IdIngredient,Unit,Value")] ProductIngredient productIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient);
            ViewBag.IdProduct = new SelectList(db.Products, "Id", "Name", productIngredient.IdProduct);
            ViewBag.Unit = new SelectList(db.Units, "Id", "Name", productIngredient.Unit);
            return View(productIngredient);
        }

        // GET: ProductIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            return View(productIngredient);
        }

        // POST: ProductIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            db.ProductIngredients.Remove(productIngredient);
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
