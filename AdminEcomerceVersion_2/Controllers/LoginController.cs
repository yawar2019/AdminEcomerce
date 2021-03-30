using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminEcomerceVersion_2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Configuration config = new Configuration();
        public ActionResult Login()
        {
            return View();
        }

        public JsonResult GetLoginJson(EcomStaffData e )
        {
            EcomData ecom_data = config.ConfigureEcomData("login_staff");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(e);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }


        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult AdminPanel()
        {
            return View();
        }
        public ActionResult BusinessOwnerPanel()
        {
            return View();
        }
    }
}