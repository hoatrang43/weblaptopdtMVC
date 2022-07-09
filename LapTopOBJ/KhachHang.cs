using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public KhachHang() { }
        public KhachHang(string makh, string tenkh, string sdt, string diachi, string gt, string user, string pass)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.GioiTinh = gt;
            this.Username = user;
            this.Password = pass;

        }
    }
}