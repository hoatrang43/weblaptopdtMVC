using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class ThuongHieu
    {
        public string MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
        public string MaLoai { get; set; }
        public ThuongHieu() { }
        public ThuongHieu(string mathuonghieu, string tenthuonghieu, string maloai)
        {
            this.MaThuongHieu = mathuonghieu;
            this.TenThuongHieu = tenthuonghieu;
            this.MaLoai = maloai;
            
        }
    }
}