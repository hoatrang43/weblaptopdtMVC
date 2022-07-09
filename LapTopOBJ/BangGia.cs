using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class BangGia
    {
        public string MaGia { get; set; }
        public double GiaBan { get; set; }
        public DateTime NgayAD { get; set; }
        public DateTime NgayKT { get; set; }
        public string MaSP { get; set; }
        public BangGia(string magia, double giaban, DateTime ngayad, DateTime ngaykt, string masp)
        {
            this.MaGia = magia;
            this.GiaBan = giaban;
            this.NgayAD = ngayad;
            this.NgayKT = ngaykt;
            this.MaSP = masp;
        }
    }
}