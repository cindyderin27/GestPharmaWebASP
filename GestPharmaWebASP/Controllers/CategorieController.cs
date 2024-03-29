﻿using GestPharmaWebASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Categorie
        [HttpGet]
        public async Task<ActionResult> AfficherCategorie()
        {
            IEnumerable<Categorie> model = new List<Categorie>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Categorie"
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IEnumerable<Categorie>>(json);
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            Categorie model = new Categorie();
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            Categorie model = new Categorie();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Categorie?id=" + id
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<Categorie>(json);
                }

            }
            return View("Edit", model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Categorie model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var json = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent
                        (
                        json,
                        Encoding.UTF8,
                        "application/json"
                        );
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response;
                        if (model.IdCategorie == 0)
                        {
                            response = await client.PostAsync
                                (
                                "http://localhost:81/GespharmWeb.Api/api/Categorie",
                                content
                                );
                        }
                        else
                        {
                            response = await client.PutAsync
                                (
                                "http://localhost:81/GespharmWeb.Api/api/Categorie",
                                content
                                );
                        }
                    }
                    return RedirectToAction("AfficherMedicament");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Categorie?id=" + id
                    );
            }
            return RedirectToAction("AfficherMedicament");
        }
    }
}
