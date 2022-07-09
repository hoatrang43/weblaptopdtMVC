using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class BaiViet
    {
        public string MaBaiViet { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public string TieuDe { get; set; }
        public string MaNV { get; set; }
        public BaiViet(string mabaiviet, string noidung, DateTime ngaydang, string tieude, string manv)
        {
            this.MaBaiViet = mabaiviet;
            this.NoiDung = noidung;
            this.MaNV = manv;
            this.TieuDe = tieude;
            this.NgayDang = ngaydang;
        }
    }
}