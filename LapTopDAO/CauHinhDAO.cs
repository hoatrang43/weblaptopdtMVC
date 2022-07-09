using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
    public class CauHinhDAO
    {
        DataHelper dh = new DataHelper();
        public List<CauHinh> GetCauHinh()
        {
            DataTable dt = dh.GetDataTable("Select*from CauHinh");
            return ToList(dt);
        }
        public List<CauHinh> ToList(DataTable dt)
        {
            List<CauHinh> l = new List<CauHinh>();
            foreach (DataRow dr in dt.Rows)
            {
                CauHinh s = new CauHinh(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                l.Add(s);
            }
            return l;
        }
        
    }
}