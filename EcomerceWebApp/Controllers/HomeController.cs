﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ecomserv.Ecom;
using Newtonsoft.Json;

namespace EcomerceWebApp.Controllers
{

    public class my_data
    {
        public string dev_id = "";
    }
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
        public ActionResult ShowAdds()
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

            ecom_data.flag = "get_ads_home";


            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                HomeController psnew = new HomeController();
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
        public ActionResult ShowBrands()
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

            ecom_data.flag = "get_brand";


            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                HomeController psnew = new HomeController();
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

        public ActionResult ShowProducts()
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

            ecom_data.flag = "get_products";


            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;
          
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ecom_data);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                HomeController psnew = new HomeController();
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

        public ActionResult ShowProducts_brandId()
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

            ecom_data.flag = "get_products";


            my_data my_data = new my_data();


            my_data.dev_id = ecom_data.dev_id;

            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(ecom_data);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                HomeController psnew = new HomeController();
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