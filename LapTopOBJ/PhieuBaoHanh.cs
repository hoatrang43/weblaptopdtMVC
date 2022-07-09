using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class PhieuBaoHanh
    {
        public string MaDonHang { get; set; }
        public DateTime NgayAD { get; set; }
        public DateTime NgayKT { get; set; }
        public string MaSP { get; set; }

        public PhieuBaoHanh(string madh, string masp, DateTime ngayad, DateTime ngaykt)
        {
            this.MaDonHang = madh;
            this.MaSP = masp;
            this.NgayAD = ngayad;
            this.NgayKT = ngaykt;
        }
    }
}