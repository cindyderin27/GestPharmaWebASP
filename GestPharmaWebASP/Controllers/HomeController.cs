using GestPharmaWebASP.Models;
using GestPharmaWebASP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
            // Get:Home
        public ActionResult Index()
        {
            return View();
        }
     
        [AllowAnonymous]
        public ActionResult contact()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        [Authorize]
        public ActionResult Administrateur()
        {
            return View();
        }
        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }

        public async Task<ActionResult> ListerCategorie()
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

    }
    
}