using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class ChiTietHoaDonNhap
    {
        public string MaHDNhap { get; set; }
        public string MaSP { get; set; }
        public double GiaNhap { get; set; }
        public int SoLuong { get; set; }

        public ChiTietHoaDonNhap(string mahdn, string masp, int sl, double gianhap)
        {
            this.MaHDNhap = mahdn;
            this.MaSP = masp;
            this.SoLuong = sl;
            this.GiaNhap = gianhap;
        }
    }
}