using GestPharmaWebASP.Models;
using GestPharmaWebASP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Controllers
{
    public class DrugController : Controller
    {
        // GET: Drug
        public ActionResult Index()
        {
            return View();
        }

        // GET: Drug/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: Drug/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drug/Create
        [HttpPost]
        public ActionResult Create(MedicamentModel model)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                MedicamentCreate useCase = new MedicamentCreate(new MedicamentCommand
                   (

                 model.IdDrug,
                 model.Reference,
                 model.NameDrug,
                 model.DateFabrication,
                 model.DatePeremption,
                 model.Prix,
                 model.Composition,
                 model.IdCategory
                   ));
                var drug = useCase.ExecuteCreateMed();
                if (drug == null)
                {
                    model.IsError = true;
                    model.Message = "An error occured! try again";
                    return View(model);
                }
                return RedirectToAction("Details");
            }
                return View(model);
           
        }

        // GET: Drug/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Drug/Edit/5
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

        // GET: Drug/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Drug/Delete/5
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
