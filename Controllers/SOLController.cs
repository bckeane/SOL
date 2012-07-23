using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSOL.Models;

namespace MvcSOL.Controllers
{
    public class SOLController : Controller
    {
        private SOLDBContext db = new SOLDBContext();

        //
        // GET: /SOL/

        public ActionResult Index()
        {
            return View(db.SOLs.ToList());
        }

        //
        // GET: /SOL/Details/5

        public ActionResult Details(int id = 0)
        {
            SOL sol = db.SOLs.Find(id);
            if (sol == null)
            {
                return HttpNotFound();
            }
            return View(sol);
        }

        //
        // GET: /SOL/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SOL/Create

        [HttpPost]
        public ActionResult Create(SOL sol)
        {
            if (ModelState.IsValid)
            {
                db.SOLs.Add(sol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sol);
        }

        //
        // GET: /SOL/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SOL sol = db.SOLs.Find(id);
            if (sol == null)
            {
                return HttpNotFound();
            }
            return View(sol);
        }

        //
        // POST: /SOL/Edit/5

        [HttpPost]
        public ActionResult Edit(SOL sol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sol);
        }

        //
        // GET: /SOL/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SOL sol = db.SOLs.Find(id);
            if (sol == null)
            {
                return HttpNotFound();
            }
            return View(sol);
        }

        //
        // POST: /SOL/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SOL sol = db.SOLs.Find(id);
            db.SOLs.Remove(sol);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchIndex(string id)
        {
            string searchString = id;
            var sols = from s in db.SOLs
                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sols = sols.Where(s => s.Case.Contains(searchString));
            }

            return View(sols);
        }


    }
}