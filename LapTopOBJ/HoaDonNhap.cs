using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class HoaDonNhap
    {
        public string MaHDNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNhaCC { get; set; }
        public string MaNV { get; set; }
        public double TongTien{ get; set; }
       
        public HoaDonNhap(string mahdn, DateTime ngaynhap, string mancc, string manv, double tongtien )
        {
            this.MaHDNhap = mahdn;
            this.NgayNhap = ngaynhap;
            this.MaNhaCC = mancc;
            this.MaNV = manv;
            this.TongTien = tongtien;
        }
    }
}