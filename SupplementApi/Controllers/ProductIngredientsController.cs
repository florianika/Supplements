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
        public ActionResult Index(int productId)
        {
            var productIngredients = db.ProductIngredients.Include(p => p.Ingredient).Include(p => p.Product).Include(p => p.Unit1).Where(p=> p.IdProduct == productId);
            return View(productIngredients.ToList());
        }

        // GET: ProductIngredients/Details/5
        public ActionResult Details(int? productId, int? ingredientId)
        {
            if (productId == null || ingredientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(new object[2] { productId, ingredientId });
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            return View(productIngredient);
        }

        // GET: ProductIngredients/Create
        public ActionResult Create(int productId)
        {
            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name");
            ViewBag.IdIngredient2 = new SelectList(db.Ingredients, "Id", "Name");
            ViewBag.IdProduct = new SelectList(db.Products.Where(p => p.Id == productId), "Id", "Name");
            ViewBag.SelectedIdProduct = productId;
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
                return RedirectToAction("Index", new { idProduct = productIngredient.IdProduct });
            }

            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient);
            ViewBag.IdIngredient2 = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient2);
            ViewBag.IdProduct = new SelectList(db.Products, "Id", "Name", productIngredient.IdProduct);
            ViewBag.Unit = new SelectList(db.Units, "Id", "Name", productIngredient.Unit);
            return View(productIngredient);
        }

        // GET: ProductIngredients/Edit/5
        public ActionResult Edit(int? productId, int? ingredientId)
        {
            if (productId == null || ingredientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //object[] parameters = new object[2];
            //parameters[0] = new  { IdProduct = productId };
            //parameters[1] = new { IdIngredient = ingredientId };
            ProductIngredient productIngredient = db.ProductIngredients.Find(new object[2] {  productId ,ingredientId  });
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient);
            ViewBag.IdIngredient2 = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient2);
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
                return RedirectToAction("Index", new { productId = productIngredient.IdProduct } );
            }
            ViewBag.IdIngredient = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient);
            ViewBag.IdIngredient2 = new SelectList(db.Ingredients, "Id", "Name", productIngredient.IdIngredient2);
            ViewBag.IdProduct = new SelectList(db.Products, "Id", "Name", productIngredient.IdProduct);
            ViewBag.Unit = new SelectList(db.Units, "Id", "Name", productIngredient.Unit);
            return View(productIngredient);
        }

        // GET: ProductIngredients/Delete/5
        public ActionResult Delete(int? productId, int? ingredientId)
        {
            if (productId == null || ingredientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(new object[2] { productId, ingredientId });
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            return View(productIngredient);
        }

        // POST: ProductIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int productId, int ingredientId)
        {
            ProductIngredient productIngredient = db.ProductIngredients.Find(new object[2] { productId, ingredientId });
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
