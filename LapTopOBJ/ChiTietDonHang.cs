using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class ChiTietDonHang
    {
        public string MaDonHang { get; set; }
        public string MaSP { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public ChiTietDonHang() { }

        public ChiTietDonHang(string madh, string masp, int sl, double dongia)
        {
            this.MaDonHang = madh;
            this.MaSP = masp;
            this.SoLuong = sl;
            this.DonGia = dongia;
        }
    }
}