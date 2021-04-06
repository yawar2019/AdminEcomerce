using ecomserv.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminEcomerceVersion_2.Models;
 

namespace AdminEcomerceVersion_2.Controllers
{
    public class ApprovalsController : Controller
    {
        // GET: Approvals
        Configuration config = new Configuration();
        public ActionResult GetApprovalRequest()
        {
            return View();
        }
        public JsonResult GetApprovalRequestJson()
        {
            EcomData ecom_data = config.ConfigureEcomData("get_requests_for_approval");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(my_data);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateApprovalRequest(string id,string type)
        {
            ViewBag.id =id;
            ViewBag.type = type;

            return View();
        }
        public JsonResult UpdateApprovalRequestJson(EcomreqForApprovalItem Req)
        {
            
            Req.date = new DateTime().ToShortDateString();


            EcomData ecom_data = config.ConfigureEcomData("update_requests_for_approval");
            my_data my_data = new my_data();
            my_data.dev_id = ecom_data.dev_id;
            ecom_data.data = Newtonsoft.Json.JsonConvert.SerializeObject(Req);
            var routes_list = config.CongifuretoJson(ecom_data);
            return Json(routes_list, JsonRequestBehavior.AllowGet);
        }
    }
}