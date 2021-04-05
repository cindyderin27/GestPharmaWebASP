using GestPharmaWebASP.Models;
using GestPharmaWebASP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize]
        public ActionResult ListeCommande()
        {
            return View();
        }
        //public ActionResult ListeMedicament()
        //{
        //    return View();
        //}
        [Authorize]
        public ActionResult Factures()
        {
            return View();
        }
        [Authorize]
        public ActionResult InfoAdmin()
        {
            return View();
        }
        public ActionResult Home1()
        {
            return View();
        }
        [Authorize]
        public ActionResult Medicament()
        {
            return View();
        }
        [Authorize]
        public ActionResult Commande()
        {
            return View();
        }

    }
    
}