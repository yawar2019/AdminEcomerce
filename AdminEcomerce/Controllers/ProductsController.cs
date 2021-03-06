﻿using AdminEcomerce.Models;
using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcomerce.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        Configuration config = new Configuration();
        public ActionResult GetProduct()
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
            return View();
        }
        public ActionResult EditProduct(int? id)
        {
            return View();
        }

        public JsonResult AddProductJson(EcomProductData e)
        {
                    EcomData ecom_data = config.ConfigureEcomData("add_product");

            //UploadFiles();

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