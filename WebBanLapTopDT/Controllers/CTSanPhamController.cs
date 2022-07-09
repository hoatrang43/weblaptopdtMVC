using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTopBUSS;
using LapTopOBJ;

namespace WebBanLapTopDT.Controllers
{
    public class CTSanPhamController : Controller
    {
        // GET: CTSanPham
        public ActionResult Index()
        {
            return View();
        }
        SanPhamBuss spb = new SanPhamBuss();
        public JsonResult GetCTSP(string ProID)
        {
            SanPham sp = spb.GetSanPham(ProID);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        ThongSoKyThuatBuss ts = new ThongSoKyThuatBuss();
        public JsonResult LayTSKT(string masp)
        {
            ThongSoKyThuat tskt = ts.LayTSKTTheoMa(masp);
            return Json(tskt, JsonRequestBehavior.AllowGet);
        }
    }
}