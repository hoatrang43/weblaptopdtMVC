using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class DongSanPham
    {
       
        public string MaDong { get; set; }
        public string TenDong{ get; set; }
        public string HeDieuHanh { get; set; }
        public string ManHinh { get; set; }
        public int SoLuong { get; set; }
        public string MaThuongHieu { get; set; }
        public DongSanPham() { }
        public DongSanPham(string madong, string tendong, string hedieuhanh, string manhinh, int sl, string mathuonghieu)
        {
            this.MaDong = madong;
            this.TenDong = tendong;
            this.HeDieuHanh = hedieuhanh;
            this.ManHinh = manhinh;
            this.SoLuong = sl;
            this.MaThuongHieu = mathuonghieu;
            
        }
    }
}