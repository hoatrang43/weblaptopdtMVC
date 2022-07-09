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
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThongBao()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ReadCustomer()
        {
            string l = "0";
            if (Session["login"] != null)
            {
                l = Session["login"].ToString();
            }
            KhachHang k = null;
            string p = "";
            if (l == "1")
            {
                p= Session["login"].ToString();
                k = JsonConvert.DeserializeObject(Session["khach"].ToString()) as KhachHang;
            }
            Console.Write(p);
            return Json(new { login = l, Khach = k }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCustomer()
        {    
            string l = "0";
            if (Session["login"] != null)
            {
                l = Session["login"].ToString();
            }
            KhachHang u = null;
            string p = "";
            if (l == "1")
            {
                string t = Session["khach"].ToString();
                //Session["khach"] = JsonConvert.SerializeObject(u);
                u = JsonConvert.DeserializeObject<KhachHang>(t) as KhachHang;

            }
            return Json(new { login = l, khach = u }, JsonRequestBehavior.AllowGet);
        }
        DatHangBuss db = new DatHangBuss();      
        public JsonResult DatHang(string khachhang, string tong, string data)
        {
            //DonDatHang ddh = JsonConvert.DeserializeObject<DonDatHang>(data);
            KhachHang u = JsonConvert.DeserializeObject<KhachHang>(khachhang);
            List<ChiTietDonHang> ctdh = JsonConvert.DeserializeObject<List<ChiTietDonHang>>(data);
            DonHang d = new DonHang();
            d.MaKH = u.MaKH;
            d.DiaChiNhan = u.DiaChi;         
            d.ThanhTien = int.Parse(tong);          
            db.DatHang(u, d, ctdh);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}