using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTopBUSS;
using LapTopOBJ;
using Newtonsoft.Json;

namespace WebBanLapTopDT.Controllers
{
    public class HomeController : Controller
    {
       LoaiSPBuss lbus = new LoaiSPBuss();
        ThuongHieuBuss thb = new ThuongHieuBuss();
        CauHinhBuss chb = new CauHinhBuss();
        DongSanPhamBus db = new DongSanPhamBus();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }

        UserBuss ub = new UserBuss();
        public JsonResult Login(string un, string pw, bool rp)
        {
            //b1: lẤY về tài khoản người dùng
            KhachHang kh = ub.CheckKhachHang(un, pw);


            if (kh == null)// đăng nhập ko thành công
            {
                Session["login"] = "0";
                Session["khach"] = "";
                return Json(new { login = "0", khach = kh }, JsonRequestBehavior.AllowGet);
            }
            else //đăng nhập thành công
            {
                if (!rp) kh.Password = "";
                Session["login"] = 1;
                Session["khach"] = JsonConvert.SerializeObject(kh);
                Session.Timeout = 360;
                return Json(new { login ="1", khach = kh }, JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult Logout()
        {
            Session.Remove("login");
            Session.Remove("khach");
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DangKi(KhachHang kh)
        {       
            string st = ub.ThemKH(kh);
            return Json(st, JsonRequestBehavior.AllowGet); 
        }
        public JsonResult LayDSKH()
        {
            List<KhachHang> lkh = ub.GetKhachHang();
            return Json(lkh, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategory()
        {
           
            List<LoaiSanPham> l = lbus.LayLoaiSP();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetThuongHieu()
        {

            List<ThuongHieu> l = thb.LayThuongHieu();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCauHinh()
        {

            List<CauHinh> l = chb.LayCauHinh();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDong()
        {

            List<DongSanPham> l = db.LayDongSanPham();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}