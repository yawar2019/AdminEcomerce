using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AdminEcomerceVersion_2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        // GET: Products
        Configuration config = new Configuration();
        public ActionResult AddProduct()
        {
            return View();
        }
        public ActionResult ShowProducts()
        {
            return View();
        }

        public ActionResult GetProductDetails(int? id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        public JsonResult GetProductJson()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_products_staff");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductDetailsJson()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_products_staff");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateProduct()
        {
            return View("TEST");
        }
        public ActionResult EditProduct(int? id)
        {
            return View();
        }

        public class RootObject
        {
            public List<EcomProductData> data { get; set; }
        }

        [HttpPost]
        public JsonResult AddProductJson(EcomProductData e, HttpPostedFileBase files)
        {
            HttpFileCollection files1 = System.Web.HttpContext.Current.Request.Files;
            string jsonString = System.Web.HttpContext.Current.Request.Params["asset"];
            

            string imgname = string.Empty;
            string ImageName = string.Empty;
            //dynamic myDetails = JsonConvert.DeserializeObject<object>(jsonString);
          // var km= JsonConvert.SerializeObject(jsonString, Newtonsoft.Json.Formatting.Indented);
            JavaScriptSerializer j = new JavaScriptSerializer();
            EcomProductData a = JsonConvert.DeserializeObject<EcomProductData>(jsonString);
            
            //Following code will check that image is there 
            //If it will Upload or else it will use Default Image

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var logo = System.Web.HttpContext.Current.Request.Files;
                for(int i = 0; i < logo.Count; i++) {
                    if (logo[i].ContentLength > 0)
                    {
                        var profileName = Path.GetFileName(logo[i].FileName);
                        var ext = Path.GetExtension(logo[i].FileName);

                        ImageName = profileName;
                        var comPath = Server.MapPath("/Images/") + ImageName;

                        logo[i].SaveAs(comPath);
                    }
                }

            }


            EcomData ecom_data = config.ConfigureEcomData("add_product");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowBrands()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_brand");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategorys()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_search_cats");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTags()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_search_cats");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            string path = Server.MapPath("~/Content/Upload/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
            }
            return Json(files.Count + " Files Uploaded!");
        }
    }
}