using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
   public class KhachHangDAO
    {
        DataHelper dh = new DataHelper();

        public List<KhachHang> LayKhachHang()
        {
            DataTable dt = dh.GetDataTable("Select * from KhachHang");
            return ToList(dt);
        }

        public List<KhachHang> ToList(DataTable dt)
        {
            List<KhachHang> l = new List<KhachHang>();

            foreach (DataRow dr in dt.Rows)
            {
                KhachHang s = new KhachHang(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                      dr[5].ToString(), dr[6].ToString());
                l.Add(s);

            }
            return l;
        }
        public string AddKhachHang(KhachHang KH)
        {
            string sql = "INSERT into KhachHang values('" + KH.MaKH + "','" + KH.TenKH + "','" + KH.SDT +
                "','" + KH.DiaChi + "','" + KH.GioiTinh + "','" + KH.Username + "','" + KH.Password + "')";
            return dh.ExecuteNonQuery(sql);
        }

        public KhachHang GetKhachHang(string us, string pas)
        {
            string st = "select*from KhachHang where (Username ='" + us + "')and(Password ='" + pas + "')";
            DataTable dt = dh.GetDataTable(st);
            KhachHang k;
            if (dt.Rows.Count > 0)
            {
                k = new KhachHang(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(),
                    dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
                return k;
            }
            else
                return null;
        }
       
        public KhachHang ReadCustomer()
        {
            DataHelper dh = new DataHelper();
            string sql = "Select *from KhachHang";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                KhachHang k = new KhachHang(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(),
                    dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
                return k;
            }
        }
    }
}
