using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcomerceVersion_2.Controllers
{
    public class AdvertisementController : Controller
    {
        Configuration config = new Configuration();
        // GET: Advertisement
        public ActionResult addAdvertisement()
        {
            return View();
        }

        public ActionResult getAdvertisement()
        {
            return View();
        }

        public ActionResult getAdvertisementDetail(int? id)
        {
            ViewBag.addsDetails = id;
            return View();
        }

        public JsonResult getAdvertisementJson()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_ads_home");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
    }
}