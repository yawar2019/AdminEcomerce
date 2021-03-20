using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcomerceVersion_2.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult addAdvertisement()
        {
            return View();
        }
    }
}