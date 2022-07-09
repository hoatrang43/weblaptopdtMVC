using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
   public class NhanVienDAO
    {

        DataHelper dh = new DataHelper();
        public List<NhanVien> GetNhanVien()
        {
            DataTable dt = dh.GetDataTable("Select * from NhanVien");
            return ToList(dt);
        }

        public List<NhanVien> ToList(DataTable dt)
        {
            List<NhanVien> l = new List<NhanVien>();

            foreach (DataRow dr in dt.Rows)
            {
                NhanVien s = new NhanVien(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                      dr[5].ToString());
                l.Add(s);

            }
            return l;
        }
        public string AddNhanVien(NhanVien nv)
        {
            string sql = "INSERT into NhanVien values('" + nv.MaNV + "','" + nv.TenNV + "','" + nv.SDT +
                "','" + nv.Email+ "','" + nv.NgaySinh+ "','" + nv.QueQuan + "')";
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
               s.SDT+ "', Email = '" + s.Email+ "', NgaySinh='" +
               s.NgaySinh + "', QueQuan='" + s.QueQuan  +"' where MaNV='" + s.MaNV + "'";
            return dh.ExecuteNonQuery(st);
        }
    }
}

