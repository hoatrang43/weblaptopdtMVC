using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
    public class LoaiSPDAO
    {
        DataHelper dh = new DataHelper();
        public List<LoaiSanPham> GetLoaiSP()
        {
            DataTable dt = dh.GetDataTable("Select*from LoaiSanPham");
            return ToList(dt);
        }

        public List<LoaiSanPham> ToList(DataTable dt)
        {
            List<LoaiSanPham> ll = new List<LoaiSanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham l = new LoaiSanPham(dr[0].ToString(),
               dr[1].ToString());
                ll.Add(l);

            }
            return ll;
        }
        public string AddLoaiSP(LoaiSanPham lsp)
        {
            string sql = "INSERT into LoaiSanPham values('" + lsp.MaLoai+ "','" + lsp.TenLoai  + "')";
            return dh.ExecuteNonQuery(sql);
        }
        public string DeleteLoaiSP(string id)
        {
            string st = "delete from LoaiSanPham where MaLoai='" + id + "'";

            string s = dh.ExecuteNonQuery(st);
            dh.Close();
            return s;

        }
        public string EditLoaiSP(LoaiSanPham s)
        {       
            string st = "update LoaiSanPham set TenLoai='" + s.TenLoai  +"' where MaLoai='" + s.MaLoai + "'";
            return dh.ExecuteNonQuery(st);
        }
    }
}