    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LapTopBUSS;
using LapTopOBJ;
using System.Web.Security;

namespace WebBanLapTopDT.Areas.Areas.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
     
        //GET: Areas/SanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoaiSP()
        {
            return View();
        }
        public ActionResult NhanVien()
        {
            return View();
        }
        public ActionResult ThuongHieu()
        {
            return View();
        }
        public ActionResult DongSP()
        {
            return View();
        }
        ThongSoKyThuatBuss tskt = new ThongSoKyThuatBuss();
        NhanVienBuss nvb = new NhanVienBuss();
        public JsonResult GetTSKT()
        {
            List<ThongSoKyThuat> st = tskt.LayThongSoKT();
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditTSKT(ThongSoKyThuat s)
        {
            string st = tskt.SuaTSKT(s);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddTSKT(ThongSoKyThuat s)
        {
            string st = tskt.ThemTSKT(s);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNhanVien()
        {
            List<NhanVien> st = nvb.LayNhanVien();
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditNhanVien(NhanVien s)
        {
            string st = nvb.SuaNV(s);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddNhanVien(NhanVien nv)
        {
            string st = nvb.ThemNV(nv);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteNhanVien(string manv)
        {
            string st = nvb.XoaNV(manv);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        ThuongHieuBuss thb = new ThuongHieuBuss();
        public JsonResult AddTH(ThuongHieu th)
        {
            string st = thb.AddThuongHieu(th);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        LoaiSPBuss lb = new LoaiSPBuss();
        public JsonResult GetLoai()
        {
            List<LoaiSanPham> lsp= lb.LayLoaiSP();
            return  Json(lsp, JsonRequestBehavior.AllowGet);
        }

    }
}