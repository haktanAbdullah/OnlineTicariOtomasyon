using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class SatısHareketController : Controller
    {
        // GET: SatısHareket
        public ActionResult Index()
        {
            return View();
        }
    }
}