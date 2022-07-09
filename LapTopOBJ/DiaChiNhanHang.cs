using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class DiaChiNhanHang
    {
        public string MaDiaChi { get; set; }
        public string DiaChiNhan { get; set; }
        public string SDTNhan { get; set; }
        public string TenNguoiNhan { get; set; }
        public string MaKH { get; set; }

        public DiaChiNhanHang(string madc, string diachi, string sdt, string ten, string makh)
        {
            this.MaDiaChi = madc;
            this.DiaChiNhan = diachi;
            this.SDTNhan = sdt;
            this.TenNguoiNhan = ten;
            this.MaKH = makh;
        }
    }
}