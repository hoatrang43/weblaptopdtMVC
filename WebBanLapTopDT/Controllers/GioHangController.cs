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
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        public RedirectToRouteResult XoaKhoiGio(string masp)
        {
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            Cart itemXoa = giohang.FirstOrDefault(m => m.MaSP == masp);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteCart(string masp)
        {
            if (Session["giohang"] != null)
            {
                List<Cart> listcart = Session["giohang"] as List<Cart>;
                int index = 0;
                foreach (var item in listcart)
                {
                    if (item.MaSP == masp)
                    {
                        listcart.RemoveAt(index);
                        break;
                    }
                    index++;
                }
                Session["giohang"] = listcart;
                return Json(listcart, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        public JsonResult XoaSP(string masp)
        {
            
                List<Cart> giohang = Session["giohang"] as List<Cart>;
                for (int i = 0; i < giohang.Count; i++)
                {
                    if (giohang[i].MaSP == masp)
                    {
                        giohang.RemoveAt(i);
                        break;
                    }
                }
                Session["giohang"] = giohang;//gán lại giỏ hàng đã cập nhật sp chọn mua lại cho session

                return Json(new { status = true }, JsonRequestBehavior.AllowGet);
           
        }

        public JsonResult GetCart()
        {
            int sl = 0;
            double TongTien = 0;
            List<Cart> ct = new List<Cart>();
            if (Session["giohang"] == null) //nếu giỏ hàng chưa đc khởi tạo
            {
                Session["giohang"] = new List<Cart>();//khởi tạo giỏ hàng
                sl = 0;
                TongTien = 0;
            }
            else
            {
                ct = Session["giohang"] as List<Cart>;
                TongTien = Convert.ToDouble(ct.Sum(s => s.DonGia * s.SoLuong));                
                sl = int.Parse(ct.Sum(s => s.SoLuong).ToString());
            }
            return Json(new { DSDONHANG = ct, SoLuong = sl, ThanhTien = TongTien }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult AddCart(SanPham sp)
        {
            if (Session["giohang"] == null)// nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<Cart>();
            }
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            Cart c = null;
            // sản phầm có trong giỏ hàng tăng số lượng sản phẩm chọn mua tăng lên 1
            if (giohang.Find(m => m.MaSP == sp.MaSP) != null) // sản phẩm có trong giỏ hàng
            {

                giohang.Find(m => m.MaSP == sp.MaSP).SoLuong = giohang.Find(m => m.MaSP == sp.MaSP).SoLuong + 1;
                //giohang.Find(m => m.MaSP == sp.MaSP).TongTien = giohang.Find(m => m.MaSP == sp.MaSP).SoLuong* giohang.Find(m => m.MaSP == sp.MaSP).DonGia;
            }
            else  // Sản phẩm chưa có trong giỏ hàng
            {
                c = new Cart();
               
                c.TenSP = sp.TenSP;
                c.MaSP = sp.MaSP;
                c.Anh = sp.AnhTo;
                c.DonGia = sp.Gia;
                c.SoLuong = 1;
                c.TongTien = c.DonGia;
                giohang.Add(c);
            }
            Session["giohang"] = giohang;
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        
        }
       
    }
}

