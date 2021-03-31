using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcomerceVersion_2.Controllers
{
    public class OffersController : Controller
    {
        // GET: Offers
        Configuration config = new Configuration();
        public ActionResult AddOffer()
        {
            return View();
        }
        [HttpPost]

        public JsonResult CreateOfferJson(EcomOfferItem ads)
        {

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            string imgname = string.Empty;
            string ImageName = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var logo = System.Web.HttpContext.Current.Request.Files["file"];
                if (logo.ContentLength > 0)
                {
                    var profileName = Path.GetFileName(logo.FileName);
                    var ext = Path.GetExtension(logo.FileName);

                    ImageName = profileName;
                    var comPath = Server.MapPath("/Images/") + ImageName;

                    logo.SaveAs(comPath);

                }

            }
            EcomData ecom_data = config.ConfigureEcomData("add_offer");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ads);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetOffer()
        {
            return View();
        }

        public JsonResult getOffersJson()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_offer");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
    }
}