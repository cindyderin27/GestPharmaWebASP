using GestPharmaWebASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Medicament> model = new List<Medicament>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:81/GespharmWeb.Api/api/Medicament");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IEnumerable<Medicament>>(json);
                }
            }
            return View(model);
        }
    }
}