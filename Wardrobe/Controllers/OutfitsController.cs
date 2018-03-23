using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe.Models;

namespace Wardrobe.Controllers
{
    public class OutfitsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Accessory).Include(o => o.Bottom).Include(o => o.Occasion).Include(o => o.Season).Include(o => o.Sho).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            ViewBag.AccID = new SelectList(db.Accessories, "AccID", "AccName");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName");
            ViewBag.OccID = new SelectList(db.Occasions, "OccID", "OccName");
            ViewBag.SeasID = new SelectList(db.Seasons, "SeasID", "SeasonName");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName");
            return View();
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutID,OutName,TopID,BottomID,ShoeID,AccID,SeasID,OccID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccID = new SelectList(db.Accessories, "AccID", "AccName", outfit.AccID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomID);
            ViewBag.OccID = new SelectList(db.Occasions, "OccID", "OccName", outfit.OccID);
            ViewBag.SeasID = new SelectList(db.Seasons, "SeasID", "SeasonName", outfit.SeasID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccID = new SelectList(db.Accessories, "AccID", "AccName", outfit.AccID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomID);
            ViewBag.OccID = new SelectList(db.Occasions, "OccID", "OccName", outfit.OccID);
            ViewBag.SeasID = new SelectList(db.Seasons, "SeasID", "SeasonName", outfit.SeasID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);
            return View(outfit);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutID,OutName,TopID,BottomID,ShoeID,AccID,SeasID,OccID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccID = new SelectList(db.Accessories, "AccID", "AccName", outfit.AccID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.BottomID);
            ViewBag.OccID = new SelectList(db.Occasions, "OccID", "OccName", outfit.OccID);
            ViewBag.SeasID = new SelectList(db.Seasons, "SeasID", "SeasonName", outfit.SeasID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
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
