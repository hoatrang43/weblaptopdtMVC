using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class DonHang
    {
        public string MaDonHang { get; set; }
        public string MaKH { get; set; }
        public string DiaChiNhan { get; set; }
        public DateTime NgayDat{ get; set; }  
        public double ThanhTien { get; set; }
        public DonHang() { }
        public DonHang(string madh, DateTime ngaydat, string makh, string diachinhan, double thanhtien)
        {
            this.MaDonHang = madh;
            this.MaKH = makh;
            this.DiaChiNhan = diachinhan;
            this.NgayDat = ngaydat;          
            this.ThanhTien = thanhtien;
        }
    }
}