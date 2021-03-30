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

        //public JsonResult CreateAdsJson(EcomAdOlaData ads)
        //{
        //    EcomData ecom_data = config.ConfigureEcomData("add_ad");
        //    my_data my_data = new my_data();
        //    my_data.dev_id = ecom_data.dev_id;
        //    ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ads);
        //    var routes_list = config.CongifuretoJson(ecom_data);
        //    return Json(routes_list, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]

        public JsonResult CreateAdsJson(EcomAdOlaData ads)
        {

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            string imgname = string.Empty;
            string ImageName = string.Empty;

            //Following code will check that image is there 
            //If it will Upload or else it will use Default Image

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var logo = System.Web.HttpContext.Current.Request.Files["file"];
                if (logo.ContentLength > 0)
                {
                    var profileName = Path.GetFileName(logo.FileName);
                    var ext = Path.GetExtension(logo.FileName);

                    ImageName = profileName;
                    var comPath = Server.MapPath("/dist/") + ImageName;

                    logo.SaveAs(comPath);
                     
                }

            }
            EcomData ecom_data = config.ConfigureEcomData("add_ad");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ads);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);


        }
    }
}