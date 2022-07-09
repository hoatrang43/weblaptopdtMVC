using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
    public class ThuongHieuDAO
    {
        DataHelper dh = new DataHelper();
        public List<ThuongHieu> GetThuongHieu()
        {
            DataTable dt = dh.GetDataTable("Select*from ThuongHieu");
            return ToList(dt);
        }
        public List<ThuongHieu> ToList(DataTable dt)
        {
            List<ThuongHieu> l = new List<ThuongHieu>();
            foreach (DataRow dr in dt.Rows)
            {
                ThuongHieu s = new ThuongHieu(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                l.Add(s);

            }
            return l;
        }
        public List<ThuongHieu> GetThuongHieuTheoLoai(string CatID)
        {
            string sqlselect;
            if (CatID != "")
            {
                sqlselect = "Select*from ThuongHieu where MaLoai='" + CatID + "'";
            }
            else
            {
               sqlselect = "Select*from ThuongHieu";
            }
            DataTable dt = dh.GetDataTable(sqlselect);
            return ToList(dt);


        }
        public string AddThuongHieu(ThuongHieu th)
        {
            string sql = "INSERT into ThuongHieu values('" + th.MaThuongHieu+ "','" + th.TenThuongHieu + "','" + th.MaLoai + "')";
            return dh.ExecuteNonQuery(sql);
        }
        public string DeleteNhanVien(string id)
        {
            string st = "delete from NhanVien where MaNV='" + id + "'";

            string s = dh.ExecuteNonQuery(st);
            dh.Close();
            return s;

        }
        public string EditNhanVien(NhanVien s)
        {

            string st = "update NhanVien set TenNV='" + s.TenNV + "', SDT ='" +
               s.SDT + "', Email = '" + s.Email + "', NgaySinh='" +
               s.NgaySinh + "', QueQuan='" + s.QueQuan + "' where MaNV='" + s.MaNV + "'";
            return dh.ExecuteNonQuery(st);
        }
    }
}