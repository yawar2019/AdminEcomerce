using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcomerceVersion_2.Controllers
{
    public class TagsController : Controller
    {
        // GET: Tags
        Configuration config = new Configuration();
        public ActionResult ShowTag()
        {
            return View();
        }

        public JsonResult GetTags()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_tag");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddTag()
        {
            return View();
        }
        public JsonResult SaveTag(EcomTagItem e)
        {
           
                EcomData ecom_data = config.ConfigureEcomData("add_tag");
                my_data my_data = new my_data();
                my_data.dev_id = ecom_data.dev_id;
                ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
                var routes_list = config.CongifuretoJson(ecom_data);
                return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult UpdateTag(int? id)
        {
            ViewBag.Tagid = id;
            return View();
        }

        public JsonResult UpdateTagInfo(EcomTagItem e)
        {
            EcomData ecom_data = config.ConfigureEcomData("update_tag");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTag(int? id)
        {
            ViewBag.Tagid = id;
            return View();
        }
    }
}