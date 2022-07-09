using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class NhaCungCap
    {
        public string MaNhaCC { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
       
        public NhaCungCap(string mancc, string tenncc, string sdt, string diachi)
        {
            this.MaNhaCC = mancc;
            this.TenNCC = tenncc;
            this.SDT = sdt;
            this.DiaChi = diachi;

        }
    }
}