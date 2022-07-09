using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class BangMau
    {
        public string MaMau{ get; set; }
        public string TenMau { get; set; }
        
        public string MaDong { get; set; }
        public string MaSP { get; set; }
        public BangMau(string mamau, string tenmau, string madong, string masp)
        {
            this.MaMau = mamau;
            this.TenMau = tenmau;
            this.MaDong = madong;
            this.MaSP = masp;
        }
    }
}