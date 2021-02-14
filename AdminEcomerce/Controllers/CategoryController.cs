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

namespace AdminEcomerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult GetCatagory()
        {
            var result = GetCategorys();
            ViewBag.result = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
        private JsonResult GetCategorys()
        {
            string url = @"http://localhost:2713/ecompublic.svc/HandleEcom";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            EcomData ecom_data = new EcomData();
            ecom_data.api_key = "ujujuaaZSW23WDEE2yhyhdujujfftr54";
            ecom_data.flag = "get_search_cats";
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

            ecom_data.flag = "get_search_cats";


            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                DefaultController psnew = new DefaultController();
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


        //====

        public class my_data
        {
            public string dev_id = "";
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        public JsonResult SaveCatagory(EcomcategoryItem e, HttpPostedFileBase IconUrl)
        {
            var result = Insert_Category(e, IconUrl);
            ViewBag.result = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCatagories(EcomcategoryItem e)
        {
            var result = UpdateCategory(e);
            ViewBag.result = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private JsonResult Insert_Category(EcomcategoryItem e, HttpPostedFileBase IconUrl)
        {
            string url = @"http://localhost:2713/ecompublic.svc/HandleEcom";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            EcomData ecom_data = new EcomData();
            ecom_data.api_key = "ujujuaaZSW23WDEE2yhyhdujujfftr54";
            ecom_data.flag = "add_category";
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

            ecom_data.flag = "add_category";


            if (e.icon_url != null )
            {
                string fileName = Path.GetFileNameWithoutExtension(IconUrl.FileName);
                string extension = Path.GetExtension(IconUrl.FileName);
                fileName = fileName  + extension;
                e.icon_url = fileName;
                IconUrl.SaveAs(Path.Combine(Server.MapPath("~/img"), fileName));
                 
            }




            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                DefaultController psnew = new DefaultController();
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

        public ActionResult EditCategory( int? id)
        {
            ViewBag.CatId = id;
            return View();
        }
        public JsonResult EditCatagoryById(int? Id)
        {
            string url = @"http://localhost:2713/ecompublic.svc/HandleEcom";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            EcomData ecom_data = new EcomData();
            ecom_data.api_key = "ujujuaaZSW23WDEE2yhyhdujujfftr54";
            ecom_data.flag = "get_category";
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

            ecom_data.flag = "get_category";



            my_data my_data = new my_data();

            EcomcategoryItem ecom_cat = new EcomcategoryItem();
            ecom_cat.cat_id = Id.ToString();


            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ecom_cat);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                DefaultController psnew = new DefaultController();
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
                DefaultController psnew = new DefaultController();
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