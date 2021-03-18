using ecomserv.Ecom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace AdminEcomerce.Models
{
    public class Configuration
    {
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
        public object CongifuretoJson(EcomData ecom_data)
        {
            string url = @"http://localhost:2713/ecompublic.svc/HandleEcom";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

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
            return routes_list;

        }
        public EcomData ConfigureEcomData(string flag)
        {
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
            ecom_data.flag = flag;
            return ecom_data;
        }
        public class my_data
        {
            public string dev_id = "";
        }
    }
    public class my_data
    {
        public string dev_id = "";
    }
}