using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Controllers
{
    public class FactureController : Controller
    {
        // GET: Facture
        public ActionResult Facture()
        {
            return View("FactureView");
        }
    }
}