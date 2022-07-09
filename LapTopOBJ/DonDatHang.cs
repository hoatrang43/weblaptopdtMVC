using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapTopOBJ
{
   public class DonDatHang
    {
        public DonDatHang() { }
        public KhachHang Khach { get; set; }
        public double TongTien { get; set; }
        public List<ChiTietDonHang> LctDonHang { get; set; }
        public DonDatHang(KhachHang kh, double tt, List<ChiTietDonHang> ct)
        {
            Khach = kh;
            TongTien = tt;
            LctDonHang = ct;
        }
    }
}
