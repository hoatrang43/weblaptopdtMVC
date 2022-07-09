using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public NhanVien() { }
      
        public NhanVien(string maNV, string tennv, string sdt, string email, string ngaysinh, string que)
        {
            this.MaNV = maNV;
            this.TenNV = tennv;
            this.SDT = sdt;
            this.Email = email;
            this.NgaySinh = ngaysinh;
            this.QueQuan = que;
          

        }
    }
}