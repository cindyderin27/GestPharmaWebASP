using GestPharmaWebASP.Models;
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
    public class MedicamentController : Controller
    {
        // GET: Medicament
        [HttpGet]
        public async Task<ActionResult> AfficherMedicament()
        {
            IEnumerable<Medicament> model = new List<Medicament>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Medicament"
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IEnumerable<Medicament>>(json);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            Medicament model = new Medicament();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Categorie"
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<IEnumerable<Categorie>>(json);
                    model.Categories = categories.Select
                    (
                        x =>
                        new SelectListItem
                        {
                            Text = x.NomCategorie,
                            Value = x.IdCategorie.ToString()
                        }
                    );
                }
            }
            return View(model);
        }



        public async Task<ActionResult> Edit(int id)
        {
            Medicament model = new Medicament();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Medicament?id=" + id
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<Medicament>(json);
                }
                response = await client.GetAsync
                   (
                    "http://localhost:81/GespharmWeb.Api/api/Categorie"
                   );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<IEnumerable<Categorie>>(json);
                    model.Categories = categories.Select
                           (
                        x =>
                        new SelectListItem
                        {
                            Text = x.NomCategorie,
                            Value = x.IdCategorie.ToString(),
                            Selected = x.IdCategorie == model.Categorie.IdCategorie
                        }
                        );
                }

            }
            return View("Edit", model);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(Medicament model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync
                        (
                        "http://localhost:81/GespharmWeb.Api/api/Categorie"
                        );
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var categories = JsonConvert.DeserializeObject<IEnumerable<Categorie>>(json);
                        model.Categories = categories.Select
                        (
                            x =>
                            new SelectListItem
                            {
                                Text = x.NomCategorie,
                                Value = x.IdCategorie.ToString(),
                                Selected = model.IdCategorie == x.IdCategorie
                            }
                        );
                    }
                }


                if (ModelState.IsValid)
                {
                    MultipartFormDataContent multipart = new MultipartFormDataContent();
                    var json = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent
                    (
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );
                    multipart.Add(content, "data");
                    //if (model.Photo.ContentLength > 0)
                    //{
                    //    byte[] picture = new byte[model.Image.ContentLength];
                    //    model.Image.InputStream.Read(picture, 0, picture.Length);
                    //    ByteArrayContent byteContent = new ByteArrayContent(picture);
                    //    multipart.Add(byteContent, "picture", model.Image.FileName);
                    //}

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response;
                        if (model.IdCategorie == 0)
                        {
                            response = await client.PostAsync
                                (
                                "http://localhost:81/GespharmWeb.Api/api/Medicament",
                                multipart
                                );
                        }
                        else
                        {
                            response = await client.PutAsync
                                (
                                "http://localhost:81/GespharmWeb.Api/api/Medicament",
                                multipart
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
                    " http://localhost:81/GespharmWeb.Api/api/Medicament?id=" + id
                    );
           
            }
            return RedirectToAction("AfficherMedicament");
        }
    }


}
