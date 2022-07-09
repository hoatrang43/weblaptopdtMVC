using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapTopOBJ
{
    public class Cart
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Anh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double TongTien { get; set; }
        public Cart() { }
        public Cart(string masp, string tensp, string anh, int sl, double gia, double tong)
        {
            this.MaSP = masp;
            this.TenSP = tensp;
            this.Anh = anh;
            this.SoLuong = sl;
            this.DonGia = gia;
            this.TongTien = tong;
        }
    }
}
