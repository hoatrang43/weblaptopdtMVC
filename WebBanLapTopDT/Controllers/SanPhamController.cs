using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LapTopBUSS;
using LapTopOBJ;

namespace WebBanLapTopDT.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamBuss spb = new SanPhamBuss();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DongSP1()
        {
            return View();
        }
        public ActionResult ThuongHieu()
        {
            return View();
        }
        public ActionResult LoaiSP()
        {
            return View();
        }
        public ActionResult SanPhamBanChay()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        public JsonResult GetProduct()
        {
            List<SanPham> sp = spb.LaySanPham();
            return Json(sp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSanPham1(string id)
        {
            spb.XoaSP1(id);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult EditSanPham1(SanPham s, ThongSoKyThuat ts)
        {
            /*string st =*/
            spb.SuaSP1(s, ts);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddSanPham(SanPham s, ThongSoKyThuat ts)
        {
            /*string st =*/
            spb.ThemSP(s, ts);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSanPham(string id)
        {
            string st = spb.XoaSP(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditSanPham(SanPham s)
        {
            string st = spb.SuaSP(s);
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TimKiemTheoTen(string tensp)
        {
            List<SanPham> sp = spb.TimKiemSPTheoTen(tensp);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductP(int pageIndex, int pageSize, string productName)
        {
            SanPhamList spl = spb.GetSanPhamP(pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }
        public JsonResult page(int page)
        {
            //if (pageindex == null)
            //{
            //    pageindex = 1;
            //}
            int pagesize = 6;
            string productName = "";
            //int pageindex = 1;

            List<SanPham> lst = spb.GetProductsP(page, pagesize, productName);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LayDSSPTheoDong(string madong)
        {
            List<SanPham> lsp = spb.LaySPTheoDong(madong);

            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LayDSSPThuongHieu(string maTH)
        {
            List<SanPham> lsp = spb.LaySanPhamThuongHieu(maTH);

            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LayDSSPTheoLoai(string maloai)
        {
            List<SanPham> lsp = spb.LaySanPhamLoai(maloai);

            return Json(lsp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayDSSPMoi()
        {
           List<SanPham> lsp = spb.GetSPMoi();

            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDSSPBanChay()
        {
            List<SanPham> lsp = spb.GetSPBanChay();

            return Json(lsp, JsonRequestBehavior.AllowGet);
        }

       

        public JsonResult Upload(string masp)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/image/" + masp + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                l.Add(pf.FileName);

            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Search1(string ma)
        {
            List<SanPham> lsp = spb.LaySanPham();
            for (int i = 0; i < lsp.Count; i++)
            {
                if (lsp[i].MaSP.Contains(ma) || lsp[i].TenSP.Contains(ma))
                {

                }
                else
                {
                    lsp.RemoveAt(i);
                    i--;
                }
            }
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        NhanVienBuss nvb = new NhanVienBuss();
        public JsonResult AddNhanVien(NhanVien nv)
        {
            string st = nvb.ThemNV(nv);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        ThuongHieuBuss thb = new ThuongHieuBuss();
        public JsonResult AddTH(ThuongHieu th)
        {
            string st = thb.AddThuongHieu(th);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
    }
}