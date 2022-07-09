using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class SanPham
    {
        public string MaDong { get; set; }
        public string MaSP{ get; set; }
        public string TenSP{ get; set; }
        public string SoMay { get; set; }
        public string SoSeri { get; set; }      
        public string AnhTo { get; set; }
        public string AnhNho { get; set; }
        public int Gia { get; set; }
        public SanPham() { }
        public SanPham(string madong, string masp, string tensp, string somay, string soseri, string anhto, string anhnho, int gia)
        {
            this.MaDong = madong;
            this.MaSP = masp;
            this.TenSP = tensp;
            this.SoMay = somay;
            this.SoSeri = soseri;         
            this.AnhTo = anhto;
            this.AnhNho = anhnho;
            this.Gia = gia;
        }
    }
}