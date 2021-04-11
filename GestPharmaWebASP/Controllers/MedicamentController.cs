using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Controllers
{
    public class MedicamentController : Controller
    {
        // GET: Medicament
        public ActionResult ListeMedicament()
        {
            return View();
        }

        // GET: Medicament/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medicament/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicament/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicament/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medicament/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicament/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medicament/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
