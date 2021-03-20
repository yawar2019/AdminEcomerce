
using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AdminEcomerceVersion_2.Controllers
{
    public class CategorysController : Controller
    {
        // GET: Categorys
        Configuration config = new Configuration();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
        public JsonResult GetCategorys()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_category");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveCatagory(EcomcategoryItem e, HttpPostedFileBase file)
        {
            var profile = Request.Files;
            string imgname = string.Empty;
            string ImageName = string.Empty;

            //if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            //{

            //    if (logo.ContentLength > 0)
            //    {
            //        var profileName = Path.GetFileName(logo.FileName);
            // var ext = Path.GetExtension(logo.FileName);
            //ImageName = e.icon_url;
            //var comPath = Server.MapPath("~/img/") + ImageName;
            // file.SaveAs(Path.Combine(Server.MapPath("~/img/"), ImageName));
            //  prdObj.ImagePath = comPath;
            // prdObj.Add()
            //return Json(db.InsertProduct(prdObj.ProductName, prdObj.ImagePath, prdObj.Description, prdObj.Price, prdObj.Category), JsonRequestBehavior.AllowGet);
            //    }
            //}


            EcomData ecom_data = config.ConfigureEcomData("add_category");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
        public class my_data
        {
            public string dev_id = "";
        }


        public JsonResult UpdateCatagories(EcomcategoryItem e)
        {
            var result = UpdateCategory(e);
            ViewBag.result = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public ActionResult UpdateCategory(int? id)
        {
            ViewBag.CatId = id;
            return View();
        }

        public ActionResult GetCategory(int? id)
        {
            ViewBag.CatId = id;
            return View();
        }

        public JsonResult GetCatagoryById(int? Id)
        {
            EcomData ecom_data = config.ConfigureEcomData("get_category");
            my_data my_data = new my_data();

            EcomcategoryItem ecom_cat = new EcomcategoryItem();
            ecom_cat.cat_id = Id.ToString();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ecom_cat);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditCatagoryById(int? Id)
        {
            EcomData ecom_data = config.ConfigureEcomData("get_category");
            my_data my_data = new my_data();

            EcomcategoryItem ecom_cat = new EcomcategoryItem();
            ecom_cat.cat_id = Id.ToString();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ecom_cat);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }


        private JsonResult UpdateCategory(EcomcategoryItem e)
        {
            string url = @"http://localhost:2713/ecompublic.svc/HandleEcom";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            EcomData ecom_data = new EcomData();
            ecom_data.api_key = "ujujuaaZSW23WDEE2yhyhdujujfftr54";

            ecom_data.dev_id = "123456";//any value
            ecom_data.dev_type = "web";//always pass it as web only.
            ecom_data.store_id = "1";//always pass 1
            ecom_data.token = "123456789";//temp token. will implement validation later.
            ecom_data.app_identity = "app.enbaar.olaala";
            ecom_data.cust_id = "1";


            ecom_data.staff_id = "1";
            ecom_data.role_type = "admin";
            ecom_data.store_id = "1";




            ecom_data.reg_id = "1";

            ecom_data.lang_code = "en";

            ecom_data.flag = "update_category";


            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                
                string json = JsonConvert.SerializeObject(ecom_data);
                json = FormatJson(json);
                streamWriter.Write(json);
            }
            var result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            object routes_list =
                   (object)json_serializer.DeserializeObject(result);

            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }



    }
}