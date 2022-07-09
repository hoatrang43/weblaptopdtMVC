using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class LoaiSanPham
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public LoaiSanPham(string maloai, string tenloai)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
        }
    }
}