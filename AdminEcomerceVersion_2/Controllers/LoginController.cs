using AdminEcomerceVersion_2.Models;
using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        [HttpPost]
        
        public ActionResult Login(string email,string password)
        {
            dbbomoNewEntities db = new dbbomoNewEntities();
            ecom_staff user = db.ecom_staff.Where(s => s.email == email && s.firebase_initial_pw == password).SingleOrDefault();

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.email, false);

                if (user.role_type.ToString() == "admin")
                {
                
                    Session["Role"] = "admin";
                    return Redirect("~/Login/AdminPanel");
                }
                else if (user.role_type.ToString() == "business_owner")
                {

                    Session["Role"] = "business_owner";
                    return Redirect("~/Login/BusinessOwnerPanel");
                }
                else
                {
                    return Redirect("~/Login/BusinessOwnerPanel");

                }
               
            }
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

        [Authorize]
        public ActionResult AdminPanel()
        {
            return View();
        }
        [Authorize]
        public ActionResult BusinessOwnerPanel()
        {
            return View();
        }
    }
}