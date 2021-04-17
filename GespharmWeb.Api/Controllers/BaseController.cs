using GespharmWeb.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GespharmWeb.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly pharrm_bdEntities db ;

        public BaseController()
        {
            db = new pharrm_bdEntities();
        }
    }
}
