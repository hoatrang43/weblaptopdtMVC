using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTopBUSS;
using LapTopOBJ;
using System.Web.Security;

namespace WebBanLapTopDT.Areas.Areas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Areas/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string us, string pw)
        {
            UserBuss usb = new UserBuss();
            Users u = usb.CheckLogin(us, pw);
            if (u == null)
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(u, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");

        }
    }
}