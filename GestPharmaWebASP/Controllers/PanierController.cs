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
    public class PanierController : Controller
    {
        // GET: Panier
        public async Task<ActionResult> Index(int? id)
        {
            Panier model = new Panier();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync
                        (
                        "http://localhost:81/GespharmWeb.Api/api/Categorie"
                        );
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var json = await response.Content.ReadAsStringAsync();
                    //    var categories = JsonConvert.DeserializeObject<IEnumerable<Categorie>>(json);
                    //    model.Categories = categories.Select
                    //    (
                    //        x =>
                    //        new SelectListItem
                    //        {
                    //            Text = x.NomCategorie,
                    //            Value = x.IdCategorie.ToString(),
                    //            Selected = model.IdCategorie == x.IdCategorie
                    //        }
                    //    );
                    //}
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
                    //    byte[] picture = new byte[model.Photo.ContentLength];
                    //    model.Photo.InputStream.Read(picture, 0, picture.Length);
                    //    ByteArrayContent byteContent = new ByteArrayContent(picture);
                    //    multipart.Add(byteContent, "picture", model.Photo.FileName);
                    //}

                    //using (HttpClient client = new HttpClient())
                    //{
                    //    HttpResponseMessage response;
                    //    if (model.IdCategorie == 0)
                    //    {
                    //        response = await client.PostAsync
                    //            (
                    //            "http://localhost:81/GespharmWeb.Api/api/Medicament",
                    //            multipart
                    //            );
                    //    }
                    //    else
                    //    {
                    //        response = await client.PutAsync
                    //            (
                    //            "http://localhost:81/GespharmWeb.Api/api/Medicament",
                    //            multipart
                    //            );
                    //    }
                    //}
                    //return RedirectToAction("AfficherMedicament");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }
    }
}