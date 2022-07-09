using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
    public class DongSanPhamDAO
    {
        DataHelper dh = new DataHelper();
        public List<DongSanPham> GetDongSanPham()
        {
            DataTable dt = dh.GetDataTable("Select*from DongSanPham");
            return ToList(dt);
        }
        public List<DongSanPham> ToList(DataTable dt)
        {
            List<DongSanPham> l = new List<DongSanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                DongSanPham s = new DongSanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse(dr[4].ToString()), dr[5].ToString());
                l.Add(s);

            }
            return l;
        }
    }
}